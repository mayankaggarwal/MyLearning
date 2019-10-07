using Aerospike.Client;
using MyProj.Aerospike.Utilities;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyProj.Aerospike
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AerospikeClient client = new AerospikeClient("13.67.43.21", 3000);
            //var stats = client.GetClusterStats();
            long numberOfRecords = 10000000;
            long recordStartIndex = 1;
            if(args!=null && args.Length == 2)
            {
                long.TryParse(args[0], out numberOfRecords);
                long.TryParse(args[1], out recordStartIndex);
            }

            string namespaceName = "test";
            string setName = "myset";
            string binName = "recommendation";


            //Write Operations
            DataModeler modeler = new DataModeler();
            Parallel.ForEach(modeler.GetData(numberOfRecords, recordStartIndex), new ParallelOptions { MaxDegreeOfParallelism = 100 }, async item =>
            {
                var json = JsonSerializer.Serialize(item);
                Key key = new Key(namespaceName, setName, item.CustomerId);
                Bin bin = new Bin(binName, json);
                client.Put(null, key, bin);
            });

            //for (long i = recordStartIndex; i <= numberOfRecords; i++)
            //{
            //    client.Delete(null, new Key(namespaceName, setName, $"{i:000000000000000}"));
            //}


            //Read Operation
            //int numberOfRetries = 1000;


            //for (int i = 0; i < numberOfRetries; i++)
            //{
            //    var key = new Key(namespaceName, setName, $"{i:0000000000}");
            //    var watch = System.Diagnostics.Stopwatch.StartNew();
            //    var result = client.Get(null, key);
            //    watch.Stop();
            //    Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            //}




            client.Close();
            Console.WriteLine("Closing");
        }
    }
}
