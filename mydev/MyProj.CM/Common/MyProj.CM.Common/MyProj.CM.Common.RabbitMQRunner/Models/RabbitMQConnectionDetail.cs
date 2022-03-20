using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Common.RabbitMQRunner.Models
{
    public class RabbitMQConnectionDetail
    {
        public string HostName { get; set; }
        public string VirtualHost { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
