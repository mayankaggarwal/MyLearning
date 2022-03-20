using Microsoft.Extensions.Logging;
using MyProj.CM.Common.RabbitMQ.Interface;
using MyProj.CM.Common.RabbitMQ.Model;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;
using System.Net.Sockets;

namespace MyProj.CM.Common.RabbitMQ
{
    public class AMQPSubscriber : RabbitMQConnection, IRabbitMQSubscriberFactory
    {
        private readonly ushort _prefetchCount;
        private readonly int _retryDurationInSeconds;
        private readonly string _queueName;
        public AMQPSubscriber(RabbitmqConnectionConfig connectionDetails, string queueName, ushort prefetchCount, int retryDurationInSeconds, ILogger<RabbitMQConnection> logger) : base(connectionDetails, retryDurationInSeconds, logger)
        {
            _prefetchCount = prefetchCount;
            _queueName = queueName;
            _retryDurationInSeconds = retryDurationInSeconds;
            Connected += OnConnected;
        }

        public bool IsSubscriberChannelConnected { get; private set; }
        public IModel ConsumerChannel { get; private set; }

        public event EventHandler<AsyncEventingBasicConsumer> ConsumerRegistered;

        private void OnConnected(object sender, bool isConnected)
        {
            if (IsConnected)
            {
                RegisterConsumer();
            }
        }

        protected virtual void RegisterConsumer()
        {
            if(!(ConsumerChannel!=null && ConsumerChannel.IsOpen))
            {
                if (!IsConnected)
                {
                    TryConnect();
                }

                var policy = Policy.Handle<BrokerUnreachableException>()
                    .Or<SocketException>()
                    .Or<OperationInterruptedException>()
                    .WaitAndRetryForever(retryAttempt => TimeSpan.FromSeconds(_retryDurationInSeconds), (ex, time) =>
                    {
                        Logger.LogError(ex, "Could not consume queue: after {Timeout}s ({ExceptionMessage})", $"{time.TotalSeconds:n1}", ex.Message);
                    });

                policy.Execute(() =>
                {
                    ConsumerChannel = GetModel();
                    var consumer = new AsyncEventingBasicConsumer(ConsumerChannel);
                    ConsumerChannel.BasicQos(prefetchSize: 0, prefetchCount: _prefetchCount, global: false);
                    Logger.LogDebug("RabbitMQ channel is trying to listening");
                    ConsumerChannel.BasicConsume(queue: _queueName, consumer: consumer, autoAck: false);
                    Logger.LogDebug("Called consume on channel");

                    ConsumerChannel.ModelShutdown += (sender, ea) =>
                    {
                        Logger.LogError("Model Shutdown :-" + ea.Cause);
                        if (ConsumerChannel.IsClosed)
                        {
                            IsSubscriberChannelConnected = false;
                            ConsumerChannel?.Close();
                            RegisterConsumer();
                        }
                    };

                    ConsumerChannel.CallbackException += (sender, ea) =>
                    {
                        Logger.LogError("Callback Exception :-" + ea.Exception);
                        if (ConsumerChannel.IsClosed)
                        {
                            IsSubscriberChannelConnected = false;
                            ConsumerChannel?.Close();
                            RegisterConsumer();
                        }
                    };

                    if(ConsumerChannel.IsOpen)
                    {
                        IsSubscriberChannelConnected = true;
                        ConsumerRegistered?.Invoke(this, consumer);
                    }
                });
            }
        }
    }
}
