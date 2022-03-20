using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProj.CM.API.Middleware
{
    public static class Extensions
    {
        public static void AddAuthProxyMoq(this IServiceCollection serviceCollection,IConfigurationSection configurationSection)
        {
            serviceCollection.Configure<AuthProxyMoqOptions>(configurationSection.Bind);
        }

        public static void UseAuthProxyMoq(this IApplicationBuilder app)
        {
            app.UseMiddleware<AuthProxyMoqMiddleware>();
        }
    }
}
