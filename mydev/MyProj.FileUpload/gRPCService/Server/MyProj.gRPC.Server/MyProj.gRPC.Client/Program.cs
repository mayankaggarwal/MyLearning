using Grpc.Core;
using MyProj.FileUpload.Model;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MyProj.gRPC.Client
{
    class Program
    {
        private static FileStream fileReader = null;
        private const int MAX_CHUNK_SIZE = (1024 * 3000);
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int port = 7001;
            Channel channel = new Channel("127.0.0.1:7001", ChannelCredentials.Insecure);
            var client = new FileUploadService.FileUploadServiceClient(channel);
            var response = client.SayHello(new MyRequest { Req = "Hello Client" });
            Console.WriteLine(response.Resp);
            string filePath = @"D:\Samples\source\customfile_4000000023-06-2019_16_09_43.csv";
            using (fileReader = new FileStream(filePath, FileMode.Open,FileAccess.Read))
            using(var call = client.SendData())
            {
                byte[] fileData;
                long fileSize = fileReader.Length;
                long remainingBytes = fileSize;
                int numberOfBytesRead = 0, done = 0;
                while (numberOfBytesRead < fileSize)
                {
                    SetByteArray(out fileData, remainingBytes);
                    done = fileReader.Read(fileData, 0, fileData.Length);
                    await call.RequestStream.WriteAsync(new MyData { Data = Google.Protobuf.ByteString.CopyFrom(fileData) });
                    //requestStream.Write(fileData, 0, fileData.Length);
                    numberOfBytesRead += done;
                    remainingBytes -= done;
                }
                await call.RequestStream.CompleteAsync();
                var response1 = await call.ResponseAsync;
                Console.WriteLine(response1.Resp);
                
            }
            channel.ShutdownAsync().Wait();
        }

        private static void SetByteArray(out byte[] fileData, long bytesLeft)
        {
            fileData = bytesLeft < MAX_CHUNK_SIZE ? new byte[bytesLeft] : new byte[MAX_CHUNK_SIZE];
        }
    }
}
