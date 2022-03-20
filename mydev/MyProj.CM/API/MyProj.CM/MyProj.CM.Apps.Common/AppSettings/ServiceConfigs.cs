using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Apps.Common.AppSettings
{
    public class ServiceConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
    }

    public class ServiceConfigs
    {
        public ServiceConfig Administration { get; set; }
    }
}
