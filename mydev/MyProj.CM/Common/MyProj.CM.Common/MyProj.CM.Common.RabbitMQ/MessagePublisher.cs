using Microsoft.Extensions.Logging;
using MyProj.CM.Common.RabbitMQ.Interface;
using MyProj.CM.Common.RabbitMQ.Model;
using MyProj.CM.Common.RabbitMQ.Type;
using Newtonsoft.Json;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using RabbitMQ.Client.Framing;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace MyProj.CM.Common.RabbitMQ
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly IRabbitMQConnectionFactory _presistentConnection;
        private readonly ILogger<MessagePublisher> _logger;
        private readonly string _exchange;
        private readonly int _retryCount;
        private readonly int _retryDurationInSeconds;
        private readonly object _syncRoot = new object();

        public MessagePublisher(ILogger<MessagePublisher> logger, IRabbitMQConnectionFactory rabbitMQConnectionFactory, string exchange, int retryCount, int retryDurationInSeconds)
        {
            _presistentConnection = rabbitMQConnectionFactory ?? throw new ArgumentNullException(nameof(rabbitMQConnectionFactory));
            _logger = logger;
            _exchange = exchange;
            _retryCount = retryCount;
            _retryDurationInSeconds = retryDurationInSeconds;
        }
        public void Publish(string correlationId, string routingKey, object args, int delayEnqueueTime = 0)
        {
            if (!_presistentConnection.IsConnected)
            {
                _presistentConnection.TryConnect();
            }

            var messageId = Guid.NewGuid().ToString();
            var brokeredEvent = new BrokeredEvent
            {
                RoutingKey = routingKey,
                Args = args,
                MessageId = messageId,
                CorrelationId = correlationId
            };
            IBasicProperties props = new BasicProperties
            {
                ContentType = "text/json",
                CorrelationId = correlationId,
                ReplyTo = routingKey,
                MessageId = messageId,
                DeliveryMode = (byte)DeliveryMode.Persistent
            };
            var message = JsonConvert.SerializeObject(brokeredEvent, new JsonSerializerSettings { Formatting = Formatting.Indented });
            var body = Encoding.UTF8.GetBytes(message);
            props.Headers = new Dictionary<string, object>()
            {
                ["x-delay"] = delayEnqueueTime > 0?delayEnqueueTime*60*1000:5000
            };
            _logger.LogDebug($"Queueing future message: {routingKey} {delayEnqueueTime}");

            var policy = Policy.Handle<BrokerUnreachableException>()
                .Or<SocketException>()
                .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(_retryDurationInSeconds), (ex, time) =>
                {
                    _logger.LogError(ex, "Could not publish event: {EventId} after {Timeout}s ({ExceptionMessage})", messageId, $"{time.TotalSeconds:n1}", ex.Message);
                });

            policy.Execute(() =>
            {
                lock (_syncRoot)
                {
                    var channel = _presistentConnection.GetModel();
                    channel.BasicPublish(_exchange, routingKey, false, props, body);
                }
            });
        }
    }
}
