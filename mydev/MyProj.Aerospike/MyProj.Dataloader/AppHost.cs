using Microsoft.Extensions.Logging;
using MyProj.DataSource.Contracts;
using MyProj.DataSource.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyProj.Dataloader
{
    public class AppHost
    {
        private readonly IDataSource _source;
        private readonly ILogger<AppHost> _logger;
        public AppHost(IDataSource source,ILogger<AppHost> logger)
        {
            _logger = logger;
            _source = source;
        }

        public void Run(long numberOfRecords,long recordStartIndex,int numberOfThreads)
        {
            _logger.LogInformation($"Runnuning with number of records {numberOfThreads} with starting index {recordStartIndex} and number of threads {numberOfThreads}");
            DataModeler modeler = new DataModeler();
            Parallel.ForEach(modeler.GetData(numberOfRecords, recordStartIndex), new ParallelOptions { MaxDegreeOfParallelism = numberOfThreads }, async item =>
                  {
                      var json = JsonSerializer.Serialize(item);
                      var response = await _source.Create(item.CustomerId, json);
                      _logger.LogInformation($"Document updated {response.Success} with id {item.CustomerId}");
                  });

            Console.WriteLine("Closing");
        }
    }
}
