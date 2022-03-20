using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using myproj.CM.Administration.Contract.Messages;
using MyProj.CM.Apps.Common.AppSettings;
using MyProj.CM.Apps.Common.Grpc;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Apps.Common
{
    public static class Bootstrap
    {
        public static void UseGrpcClient(this IServiceCollection service,IConfiguration configuration)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttphandler.Http2UnencryptedSupport", true);
            var maxReceiveMessageSize = 100;
            var maxSendMessageSize = 100;

            var serviceConfigs = configuration.GetSection("ServiceConfigs").Get<ServiceConfigs>();

            if (serviceConfigs.Administration != null)
            {
                service.AddGrpcClient<AdministrationService.AdministrationServiceClient>(m =>
                {
                    m.Address = new Uri($"http://{serviceConfigs.Administration.Host}:{serviceConfigs.Administration.Port}");
                }).ConfigureChannel(s =>
                {
                    s.MaxReceiveMessageSize = int.MaxValue;
                    s.MaxSendMessageSize = int.MaxValue;
                }).AddInterceptor(() => new RPCRetryInterceptor());
                service.AddTransient<IAdministration, Administration>();
            }
            //service.AddTransient<IAdministration, Administration>();

        }
    }
}
