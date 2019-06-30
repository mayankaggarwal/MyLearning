using Grpc.Core;
using MyProj.DataUpload.gRPC.Server;
using System;

namespace MyProj.DataUpload.gRPC.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 7002;
            //Console.WriteLine("Hello World!");
            Grpc.Core.Server server = new Grpc.Core.Server
            {
                Services = { FileUpload.Model.FileUploadService.BindService(new FileUploadServer()) },
                Ports = { new ServerPort("localhost", port, ServerCredentials.Insecure) }
            };
            server.Start();
            Console.WriteLine("RouteGuide server listening on port " + port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
