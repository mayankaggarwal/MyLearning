using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyProj.CM.Common.RabbitMQ.Interface;
using MyProj.CM.Common.RabbitMQ.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Common.RabbitMQ
{
    public static class Bootstrap
    {
        public static void UseRabbitmqPublishContext(this IServiceCollection collection, RabbitmqConnectionConfig connectionDetails,string exchange,int retryCount,int retryDurationInSeconds)
        {
            if (string.IsNullOrWhiteSpace(exchange) || retryCount <= 0 || retryDurationInSeconds <= 0) throw new Exception("Invalid Input");
            collection.AddSingleton<IRabbitMQConnectionFactory>(new RabbitMQConnection(connectionDetails, retryDurationInSeconds, collection.BuildServiceProvider().GetService<ILogger<RabbitMQConnection>>()));
            collection.AddSingleton<IMessagePublisher>(new MessagePublisher(collection.BuildServiceProvider().GetService<ILogger<MessagePublisher>>(), collection.BuildServiceProvider().GetService<IRabbitMQConnectionFactory>(), exchange, retryCount, retryDurationInSeconds));
        }

        public static void UseRabbitmqReceiveContext(this IServiceCollection collection, RabbitmqConnectionConfig connectionDetails, string queue, ushort prefetchCount, int retryDurationInSeconds)
        {
            if (string.IsNullOrWhiteSpace(queue) || prefetchCount <= 0 || retryDurationInSeconds <= 0) throw new Exception("Invalid Input");
            collection.AddSingleton<IRabbitMQConnectionFactory>(new RabbitMQConnection(connectionDetails, retryDurationInSeconds, collection.BuildServiceProvider().GetService<ILogger<RabbitMQConnection>>()));
            collection.AddSingleton<IRabbitMQSubscriberFactory>(new AMQPSubscriber(connectionDetails,queue,prefetchCount,retryDurationInSeconds,collection.BuildServiceProvider().GetService<ILogger<RabbitMQConnection>>()));
            collection.AddSingleton<IMessageReceiverHandler>(new MessageReceiver(collection.BuildServiceProvider().GetService<IRabbitMQSubscriberFactory>(), collection.BuildServiceProvider().GetService<ILogger<MessageReceiver>>()));
        }
    }
}
