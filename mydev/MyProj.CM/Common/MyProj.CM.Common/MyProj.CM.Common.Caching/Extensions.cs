using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Common.Caching
{
    public static class Extensions
    {
        public static void UseMemoryCache(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ICache, LocalCache>();
        }
    }
}
