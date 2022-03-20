using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR("/signalr",new Microsoft.AspNet.SignalR.HubConfiguration());
        }
    }
}