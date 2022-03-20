using Microsoft.Extensions.Configuration;
using MyProj.CM.Common.RabbitMQRunner.Models;
using System;

namespace MyProj.CM.Common.RabbitMQRunner
{
    class Program
    {
        internal static IConfiguration Configuration;
        static void Main(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Console.WriteLine("Hello World!");
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true);
            Configuration = builder.Build();

            var connectionDetails = new RabbitMQConnectionDetail();
            var topologyFileName = Configuration.GetValue<string>("TopologyFileName");
            Configuration.Bind("RabbitMq.ConnectionString", connectionDetails);
            var rabbitmqTopologyService = new RabbitmqTopologyService();
            var connection = rabbitmqTopologyService.GetConnection(connectionDetails);
            rabbitmqTopologyService.CreateMessageDeliveryTopology(connection, topologyFileName);
            Environment.Exit(1);
        }
    }
}
