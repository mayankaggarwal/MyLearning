using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyProj.DataSource.Aerospike;
using System;
using System.IO;

namespace MyProj.Dataloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var config = LoadConfiguration();
            var loggerFactory = LoadLogging();

            var serviceProvider = new ServiceCollection()
                .AddSingleton(LoadLogging())
                .AddLogging()
                .AddSingleton<AppHost, AppHost>()
                .AddSingleton(config)
                .UseAerospike(config)
                .BuildServiceProvider();

            var numberOfDocuments = config.GetValue<long>("NumberOfDocuments");
            var recordStartIndex = config.GetValue<long>("RecordStartIndex");
            var numberOfThreads = config.GetValue<int>("NumberOfThreads");

            serviceProvider.GetService<AppHost>().Run(numberOfDocuments, recordStartIndex, numberOfThreads);
        }

        static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        static ILoggerFactory LoadLogging()
        {
            return LoggerFactory.Create(builder =>
            {
                builder.ClearProviders()
                .AddConsole()
                .AddDebug();
            });
        }
    }
}
