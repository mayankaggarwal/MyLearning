using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Common.RabbitMQ.Model
{
    public class BrokeredEvent
    {
        public string CorrelationId { get; set; }
        public string RoutingKey { get; set; }
        public string MessageId { get; set; }
        public object Args { get; set; }
    }
}
