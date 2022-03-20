using Microsoft.Extensions.Logging;
using MyProj.CM.Common.RabbitMQ.Interface;
using MyProj.CM.Common.RabbitMQ.Model;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace MyProj.CM.Common.RabbitMQ
{
    public class RabbitMQConnection:IRabbitMQConnectionFactory, IDisposable
    {
        private readonly IConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;
        private readonly int _retryDurationInSeconds;

        protected readonly ILogger<RabbitMQConnection> Logger;
        private bool _disposed;
        private readonly object _syncRoot = new object();

        public event EventHandler<bool> Connected;
        public RabbitMQConnection(RabbitmqConnectionConfig connectionDetails, int retryDurationInSeconds, ILogger<RabbitMQConnection> logger)
        {
            _connectionFactory = new ConnectionFactory
            {
                HostName = connectionDetails.HostName,
                Port = connectionDetails.Port,
                VirtualHost = connectionDetails.VirtualHost,
                UserName = connectionDetails.UserName,
                Password = connectionDetails.Password,
                DispatchConsumersAsync = connectionDetails.DispatchConsumerAsync,
                Ssl = new SslOption
                {
                    ServerName = connectionDetails.SslServerName,
                    Enabled = connectionDetails.SslEnabled,
                    CertPath = connectionDetails.SslCertPath,
                    CertPassphrase = connectionDetails.SslCertPassphrase
                }
            };
            _retryDurationInSeconds = retryDurationInSeconds;
            Logger = logger;
        }
        public bool IsConnected => _connection != null && _connection.IsOpen && !_disposed;
        public bool TryConnect()
        {
            Logger.LogDebug("RabbitMQ Client is trying to connect");
            var policy = Policy.Handle<BrokerUnreachableException>()
                .Or<SocketException>()
                .WaitAndRetryForever(retryAttempt => TimeSpan.FromSeconds(_retryDurationInSeconds), (ex, time) =>
                {
                    Logger.LogError(ex, "Rabbitmq Connect failed after {Timeout}s :-", $"{time.TotalSeconds:n1}", ex.Message);
                });
            policy.Execute(() =>
            {
                lock (_syncRoot)
                {
                    _connection?.Close();
                    _connection = _connectionFactory.CreateConnection();
                    Logger.LogDebug("Connected");
                    _connection.CallbackException += ConnectionOnCallbackException;
                    _connection.ConnectionBlocked += ConnectionOnConnectionBlocked;
                    _connection.ConnectionShutdown += ConnectionOnConnectionShutdown;
                    Connected?.Invoke(nameof(RabbitMQConnection), true);
                }
            });
            return true;
        }

        private void ConnectionOnConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            if (_disposed) return;
            Logger.LogError("Connection Shutdown :-" + e.Cause);
            TryConnect();
        }

        private void ConnectionOnConnectionBlocked(object sender, ConnectionBlockedEventArgs e)
        {
            if (_disposed) return;
            Logger.LogError("Connection Blocked :-" + e.Reason);
            CloseConnection();
            TryConnect();
        }

        private void ConnectionOnCallbackException(object sender, CallbackExceptionEventArgs e)
        {
            if (_disposed) return;
            Logger.LogError("Connection Callback Exception :-" + e.Exception);
            CloseConnection();
            TryConnect();
        }

        public IModel GetModel()
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("No RabbitMQ Connections Available");
            }
            if(_channel == null || (_channel !=null && _channel.IsClosed))
            {
                try
                {
                    _channel = _connection.CreateModel();
                }
                catch(Exception exp)
                {
                    Logger.LogError(exp, exp.Message);
                    CloseChannel();
                    CloseConnection();
                    TryConnect();
                    _channel = _connection.CreateModel();
                }
            }

            return _channel;
        }

        private void CloseChannel()
        {
            if (_channel != null)
            {
                try
                {
                    _channel.Close();
                }
                catch(Exception exp)
                {
                    Logger.LogError(exp, "Channel Close failed:-" + exp.Message);
                }
            }
        }

        private void CloseConnection()
        {
            if (_connection != null)
            {
                try
                {
                    _connection.Close();
                }
                catch (Exception exp)
                {
                    Logger.LogError(exp, "Connection Close failed:-" + exp.Message);
                }
            }
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            try
            {
                if(_connection != null && _connection.IsOpen)
                {
                    _connection.Close();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
