using Grpc.Core;
using MyProj.FileUpload.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.gRPC.Server
{
    public class FileUploadServer:FileUploadService.FileUploadServiceBase
    {
        public override Task<MyResponse> SayHello(MyRequest request, ServerCallContext context)
        {
            return Task.FromResult(new MyResponse { Resp = request.Req + " Addition from server" });
        }

        public override async Task<MyResponse> SendData(IAsyncStreamReader<MyData> requestStream, ServerCallContext context)
        {
            using (var fileStream = new FileStream(@"D:\Samples\Upload\customfile_4000000023-06-2019_16_09_43.csv", FileMode.OpenOrCreate, FileAccess.Write))
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
