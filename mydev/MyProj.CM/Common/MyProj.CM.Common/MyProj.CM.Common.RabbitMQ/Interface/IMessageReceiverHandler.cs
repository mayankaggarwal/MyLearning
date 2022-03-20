using MyProj.CM.Common.RabbitMQ.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Common.RabbitMQ.Interface
{
    public interface IMessageReceiverHandler
    {
        void AddSubscription(EventHandler<BrokeredEvent> messageReceivedtrigger, EventHandler<BrokeredEvent> processCompleteFailed);
    }
}
