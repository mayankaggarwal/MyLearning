using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Common.RabbitMQRunner.Models
{
    public class RabbitMQExchange
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Durable { get; set; }
        public bool AutoDelete { get; set; }
        public bool MessageDelayEnable { get; set; }
        public IEnumerable<RabbitMQQueue> Queue { get; set; }
        public int ExchangeVersion { get; set; }
    }
}
