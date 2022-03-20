using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Common.RabbitMQ.Interface
{
    public interface IRabbitMQConnectionFactory
    {
        bool IsConnected { get; }
        bool TryConnect();
        IModel GetModel();
        event EventHandler<bool> Connected;
    }
}
