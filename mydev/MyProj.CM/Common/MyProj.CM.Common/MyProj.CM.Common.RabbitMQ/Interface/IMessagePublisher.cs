using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Common.RabbitMQ.Interface
{
    public interface IMessagePublisher
    {
        void Publish(string correlationId, string routingKey, object args, int delayEnqueueTime = 0);
    }
}
