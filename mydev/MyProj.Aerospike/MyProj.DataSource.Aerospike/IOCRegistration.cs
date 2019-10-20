using Aerospike.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyProj.DataSource.Aerospike.Models;
using MyProj.DataSource.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MyProj.DataSource.Aerospike
{
    public static class IOCRegistration
    {
        public static IServiceCollection UseAerospike(this IServiceCollection services,IConfiguration config)
        {
            var hosts = config["aerospikehosts"]?.Split(',')?
                .Select(x => x.Split(':')).ToDictionary(split => split[0], split => int.Parse(split[1]))
                .Select(m=>new Host(m.Key,m.Value)).ToArray();
            services.AddSingleton<IAerospikeClient>(new AerospikeClient(null, hosts));
            services.AddSingleton<IAerospikeConfig>(new AerospikeConfig(config["namespace"], config["setname"], config["binname"]));
            services.AddTransient<IDataSource, DataSource>();
            return services;
        }
    }
}
