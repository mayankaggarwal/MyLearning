using Microsoft.AspNetCore.Mvc;
using System;
using FileUploadWebApi.Helpers;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Net.Http.Headers;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FileUploadWebApi.Controllers
{
    [Route("api/[controller]")]
    public class StreamingController:Controller
    {
        private static readonly FormOptions _defaultFormOptions = new FormOptions();
        const string FILE_PATH = @"D:\Samples\";

        [HttpPost]
        public async Task<IActionResult> Post(){
            if(!MultipartRequestHelper.IsMultipartContentType(Request.ContentType)){
                return BadRequest($"Expected a multipart request");
            }

            var formAccumulator = new KeyValueAccumulator();
            string targetFilePath = null;
            
            var boundary = MultipartRequestHelper.GetBoundary(MediaTypeHeaderValue.Parse(Request.ContentType),_defaultFormOptions.MultipartBoundaryLengthLimit);
            var reader = new MultipartReader(boundary, HttpContext.Request.Body);
            var section = await reader.ReadNextSectionAsync();
            while(section!=null){
                 ContentDispositionHeaderValue contentDisposition;
                 var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(section.ContentDisposition, out contentDisposition);
                 string fileName = ContentDispositionHeaderValue.Parse(section.ContentDisposition).FileName.ToString().Trim('"');
                if (hasContentDispositionHeader)
                {
                    if (MultipartRequestHelper.HasFileContentDisposition(contentDisposition))
                    {
                        targetFilePath =Path.Combine(FILE_PATH,fileName);
                        using (var targetStream = System.IO.File.Create(targetFilePath))
                        {
                            await section.Body.CopyToAsync(targetStream);
                        }
                    }
                    else if (MultipartRequestHelper.HasFormDataContentDisposition(contentDisposition))
                    {
                        // Content-Disposition: form-data; name="key"
                        //
                        // value

                        // Do not limit the key name length here because the 
                        // multipart headers length limit is already in effect.
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
            return Ok("Done");
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
    }
}