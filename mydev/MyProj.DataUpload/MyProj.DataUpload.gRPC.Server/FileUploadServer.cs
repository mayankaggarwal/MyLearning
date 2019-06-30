using Grpc.Core;
using MyProj.FileUpload.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MyProj.DataUpload.gRPC.Server
{
    public class FileUploadServer:FileUploadService.FileUploadServiceBase
    {
        public override Task<MyResponse> SayHello(MyRequest request, ServerCallContext context)
        {
            return Task.FromResult(new MyResponse { Resp = request.Req + " Addition from server" });
        }

        public override async Task<MyResponse> SendData(IAsyncStreamReader<MyData> requestStream, ServerCallContext context)
        {
            string folderPath = @"D:\Samples\Upload";
            string fileName = "custumfile" + DateTime.Now.ToString().Replace(' ', '_').Replace(':', '_') + ".csv";
            string filePath = Path.Combine(folderPath, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                while (await requestStream.MoveNext())
                {
                    var data = requestStream.Current;
                    var byteArray = data.Data.ToByteArray();
                    fileStream.Write(byteArray, 0, byteArray.Length);

                }
            }

            return await Task.FromResult(new MyResponse { Resp = "File Written" });
        }
    }
}
