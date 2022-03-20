using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Common.RabbitMQ.Model
{
    public class RabbitmqConnectionConfig
    {
        public string HostName { get; set; }
        public string VirtualHost { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool DispatchConsumerAsync { get; set; }
        public bool SslEnabled { get; set; }
        public string SslServerName { get; set; }
        public string SslCertPath { get; set; }
        public string SslCertPassphrase { get; set; }
    }
}
