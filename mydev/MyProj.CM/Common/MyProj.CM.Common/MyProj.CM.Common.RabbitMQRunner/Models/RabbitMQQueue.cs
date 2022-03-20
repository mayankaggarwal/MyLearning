using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Common.RabbitMQRunner.Models
{
    public class RabbitMQQueue
    {
        public string Exchange { get; set; }
        public string Name { get; set; }
        public bool ExchangeDurable { get; set; }
        public bool Durable { get; set; }
        public string Queue { get; set; }
        public bool Exclusive { get; set; }
        public bool QueueDurable { get; set; }
        public bool AutoDelete { get; set; }
        public bool QueueExclusive { get; set; }
        public Dictionary<string,object> Properties { get; set; }
        public bool QueueAutoDelete { get; set; }
        public Dictionary<string,object> QueueProperties { get; set; }
        public string[] RoutingKeys { get; set; }
    }
}
