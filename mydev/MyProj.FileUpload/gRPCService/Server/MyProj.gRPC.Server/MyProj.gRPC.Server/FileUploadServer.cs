using Google.Cloud.Storage.V1;
using Grpc.Core;
using MyProj.FileUpload.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MyProj.gRPC.Server
{
    public class FileUploadServer : FileUploadService.FileUploadServiceBase
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

        public override async Task<MyResponse> SendDataForCloud(IAsyncStreamReader<MyData> requestStream, ServerCallContext context)
        {
            GCSWrapper wrapper = new GCSWrapper();
            string fileName = "custumfile" + DateTime.Now.ToString().Replace(' ', '_').Replace(':', '_') + ".csv";
            using (var stream = new MemoryStream())
                {
                    using(BinaryWriter writer = new BinaryWriter(stream)){
                    while (await requestStream.MoveNext())
                    {
                
                    
                        var data = requestStream.Current;
                        var byteArray = data.Data.ToByteArray();
                        Console.WriteLine("Number of bytes written" + byteArray.Length);
                        writer.Write(byteArray);
                        
                    }
                    wrapper.UploadFromStream(stream,fileName);
                }
                
            }

            return await Task.FromResult(new MyResponse { Resp = "File Written" });
        }
    }

    public class GCSWrapper
    {
        public async void UploadFromStream(Stream stream,string fileName)
        {
            string folderPath = @"D:\Samples\Upload";
            string filePath = Path.Combine(folderPath, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write))
            {
                    await stream.CopyToAsync(fileStream);
                    //stream.Position=0;
                //}
            }
        }

        public void UploadFromStream2(Stream stream,string fileName)
        {
            string folderPath = @"D:\Samples\Upload";
            string filePath = Path.Combine(folderPath, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write))
            {
                byte[] buffer = new byte[32768];
                int read;
                while((read = stream.Read(buffer,0,buffer.Length))>0){
                    Console.WriteLine("Writing" + read);
                    fileStream.Write(buffer,0,read);
                }
                Console.WriteLine("Failed to read anything");
            }
        }

        public void UploadFromStream3(Stream stream,string fileName)
        {
            string folderPath = @"D:\Samples\Upload";
            string filePath = Path.Combine(folderPath, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write))
            {
                using(var reader = new BinaryReader(stream)){

                    Byte[] lnByte = reader.ReadBytes(10000);
                    fileStream.Write(lnByte, 0, lnByte.Length);
                    Console.WriteLine("Failed to read anything" + lnByte.Length);
                }
            }
        }
    }
}
