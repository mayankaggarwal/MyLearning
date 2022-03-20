using Microsoft.Extensions.Logging;
using MyProj.CM.Common.RabbitMQ.Interface;
using MyProj.CM.Common.RabbitMQ.Model;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.CM.Common.RabbitMQ
{
    public class MessageReceiver : IMessageReceiverHandler
    {
        private readonly IRabbitMQSubscriberFactory _persistentConnection;
        private readonly ILogger<MessageReceiver> _logger;
        public bool IsRegistered { get; set; }
        public event EventHandler<BrokeredEvent> MessageReceivedTrigger;
        public event EventHandler<BrokeredEvent> ProcessCompleteFailed;
        public MessageReceiver(IRabbitMQSubscriberFactory rabbitMqConnectionFactory,ILogger<MessageReceiver> logger)
        {
            _persistentConnection = rabbitMqConnectionFactory ?? throw new ArgumentNullException(nameof(rabbitMqConnectionFactory));
            _logger = logger;
        }
        public void AddSubscription(EventHandler<BrokeredEvent> messageReceivedtrigger, EventHandler<BrokeredEvent> processCompleteFailed)
        {
            if (!IsRegistered)
            {
                MessageReceivedTrigger += messageReceivedtrigger;
                ProcessCompleteFailed += processCompleteFailed;
                _persistentConnection.ConsumerRegistered += PersistentConnectionOnConsumerRegistered;
                if (!_persistentConnection.TryConnect())
                {
                    throw new Exception("Failed to connect");
                }
                IsRegistered = true;
            }
        }

        private void PersistentConnectionOnConsumerRegistered(object sender, AsyncEventingBasicConsumer e)
        {
            e.Received += ConsumerOnReceived;
        }

        private async Task ConsumerOnReceived(object sender, BasicDeliverEventArgs @event)
        {
            var brokeredEvent = new BrokeredEvent();
            try
            {
                brokeredEvent = JsonConvert.DeserializeObject<BrokeredEvent>(Encoding.UTF8.GetString(@event.Body), new JsonSerializerSettings { Formatting = Formatting.Indented });
                brokeredEvent.MessageId = @event.DeliveryTag.ToString();
                await OnMessageProcess(sender, brokeredEvent);
                PositiveAcknowledgeMessage(sender, brokeredEvent);
            }
            catch(Exception exp)
            {
                _logger.LogError(exp, exp.Message);
                NegativeAcknowledgeMessage(sender, @event?.DeliveryTag.ToString(),brokeredEvent.RoutingKey);
            }
        }

        private void NegativeAcknowledgeMessage(object sender, string messageId, string routingKey)
        {
            try
            {
                var channel = _persistentConnection.ConsumerChannel;
                if (!_persistentConnection.IsConnected || !channel.IsOpen)
                {
                    _persistentConnection.TryConnect();
                    ProcessCompleteFailed?.Invoke(sender, new BrokeredEvent { MessageId = messageId, RoutingKey = routingKey });
                    return;
                }
                ulong.TryParse(messageId, out ulong tag);
                lock (channel)
                {
                    channel.BasicReject(deliveryTag: tag,false);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                ProcessCompleteFailed?.Invoke(sender, new BrokeredEvent { MessageId = messageId, RoutingKey = routingKey });
            }
        }

        private void PositiveAcknowledgeMessage(object sender, BrokeredEvent brokeredEvent)
        {
            _logger.LogDebug($"Acknowledging with message id {brokeredEvent.MessageId}");
            try
            {
                var channel = _persistentConnection.ConsumerChannel;
                if(!_persistentConnection.IsConnected || !channel.IsOpen)
                {
                    _persistentConnection.TryConnect();
                    ProcessCompleteFailed?.Invoke(sender, brokeredEvent);
                    return;
                }
                ulong.TryParse(brokeredEvent.MessageId, out ulong tag);
                lock (channel)
                {
                    channel.BasicAck(deliveryTag: tag, multiple: false);
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e, e.Message);
                ProcessCompleteFailed?.Invoke(sender, brokeredEvent);
            }
        }

        private async Task OnMessageProcess(object sender, BrokeredEvent brokeredEvent)
        {
            await Task.Run(() => MessageReceivedTrigger?.Invoke(sender, brokeredEvent));
        }
    }
}
