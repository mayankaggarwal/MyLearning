using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using MyProj.DataUpload.WebApi.Helper;
using MyProj.FileUpload.Model;

namespace MyProj.DataUpload.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private static readonly FormOptions _defaultFormOptions = new FormOptions();
        const string FILE_PATH = @"D:\Samples\";
        private const int MAX_CHUNK_SIZE = (1024 * 3000);

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            string responseMessage = "Not Done";
            if (!MultipartRequestHelper.IsMultipartContentType(Request.ContentType))
            {
                return BadRequest($"Expected a multipart request");
            }

            Channel channel = new Channel("127.0.0.1:7002", ChannelCredentials.Insecure);
            var client = new FileUploadService.FileUploadServiceClient(channel);

            var formAccumulator = new KeyValueAccumulator();
            var boundary = MultipartRequestHelper.GetBoundary(MediaTypeHeaderValue.Parse(Request.ContentType), _defaultFormOptions.MultipartBoundaryLengthLimit);
            var reader = new MultipartReader(boundary, HttpContext.Request.Body);
            using (var call = client.SendData())
            {
                var section = await reader.ReadNextSectionAsync();
                while (section != null)
                {
                    ContentDispositionHeaderValue contentDisposition;
                    var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(section.ContentDisposition, out contentDisposition);
                    string fileName = ContentDispositionHeaderValue.Parse(section.ContentDisposition).FileName.ToString().Trim('"');
                    if (hasContentDispositionHeader)
                    {
                        if (MultipartRequestHelper.HasFileContentDisposition(contentDisposition))
                        {

                            using(MemoryStream ms = new MemoryStream())
                            {
                                section.Body.CopyTo(ms);
                                ms.Position=0;
                                byte[] fileData;
                                long fileSize = ms.Length;
                                long remainingBytes = fileSize;
                                int numberOfBytesRead = 0, done = 0;
                                while (numberOfBytesRead < fileSize)
                                {
                                    SetByteArray(out fileData, remainingBytes);
                                    done = ms.Read(fileData, 0, fileData.Length);
                                    await call.RequestStream.WriteAsync(new MyData { Data = Google.Protobuf.ByteString.CopyFrom(fileData) });
                                    numberOfBytesRead += done;
                                    remainingBytes -= done;
                                }
                            }


                        }
                        else if (MultipartRequestHelper.HasFormDataContentDisposition(contentDisposition))
                        {
                            var key = HeaderUtilities.RemoveQuotes(contentDisposition.Name);
                            var encoding = GetEncoding(section);
                            using (var streamReader = new StreamReader(
                                section.Body,
                                encoding,
                                detectEncodingFromByteOrderMarks: true,
                                bufferSize: 1024,
                                leaveOpen: true))
                            {
                                // The value length limit is enforced by MultipartBodyLengthLimit
                                var value = await streamReader.ReadToEndAsync();
                                if (String.Equals(value, "undefined", StringComparison.OrdinalIgnoreCase))
                                {
                                    value = String.Empty;
                                }
                                formAccumulator.Append(key.ToString(), value);

                                if (formAccumulator.ValueCount > _defaultFormOptions.ValueCountLimit)
                                {
                                    throw new InvalidDataException($"Form key count limit {_defaultFormOptions.ValueCountLimit} exceeded.");
                                }
                            }
                        }
                    }

                    // Drains any remaining section body that has not been consumed and
                    // reads the headers for the next section.
                    section = await reader.ReadNextSectionAsync();
                }
                await call.RequestStream.CompleteAsync();
                var response1 = await call.ResponseAsync;
                responseMessage = response1.Resp;
            }
            return Ok(responseMessage);
        }
        private static Encoding GetEncoding(MultipartSection section)
        {
            MediaTypeHeaderValue mediaType;
            var hasMediaTypeHeader = MediaTypeHeaderValue.TryParse(section.ContentType, out mediaType);
            // UTF-7 is insecure and should not be honored. UTF-8 will succeed in 
            // most cases.
            if (!hasMediaTypeHeader || Encoding.UTF7.Equals(mediaType.Encoding))
            {
                return Encoding.UTF8;
            }
            return mediaType.Encoding;

        }

        private static void SetByteArray(out byte[] fileData, long bytesLeft)
        {
            fileData = bytesLeft < MAX_CHUNK_SIZE ? new byte[bytesLeft] : new byte[MAX_CHUNK_SIZE];
        }
    }
}