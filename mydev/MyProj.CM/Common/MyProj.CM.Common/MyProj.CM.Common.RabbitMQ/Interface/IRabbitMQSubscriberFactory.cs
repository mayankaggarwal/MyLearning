using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Common.RabbitMQ.Interface
{
    public interface IRabbitMQSubscriberFactory:IRabbitMQConnectionFactory
    {
        bool IsSubscriberChannelConnected { get; }
        IModel ConsumerChannel { get; }
        event EventHandler<AsyncEventingBasicConsumer> ConsumerRegistered;
    }
}
