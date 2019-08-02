using FileApi.Models;
using LoggerModule;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using FileApi.Common;

namespace FileApi.Controllers
{
    [RoutePrefix("filestreaming")]
    public class FileStreamController : ApiController
    {
        IFileOperations fileOperations;
        ICustomLogger Logger;
        public FileStreamController()
        {
            Logger = new CustomLogger();
            fileOperations = new FileOperations(Logger);
        }
        [Route("test")]
        public HttpResponseMessage GetApiTest()
        {
            return new HttpResponseMessage { Content = new StringContent("Hello World") };
        }

        [Route("files")]
        public IHttpActionResult GetFileNames()
        {
            List<string> fileNames = new List<string>();
            var files = fileOperations.GetFileNames();
            if (files != null)
                fileNames.AddRange(files.Select(x=>Path.GetFileNameWithoutExtension(x)));
            return Ok(fileNames);
        }

        [Route("files/{filename}")]
        public HttpResponseMessage GetFile(string filename)
        {
            
            HttpResponseMessage response = Request.CreateResponse();
            try
            {
                string filePath = fileOperations.GetFilePath(filename);
                FileInfo fileInfo = new FileInfo(filePath);

                if (!fileInfo.Exists)
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound,"", new MediaTypeHeaderValue("text/json"));
                }
                else
                {
                    response.Headers.AcceptRanges.Add("bytes");
                    response.StatusCode = HttpStatusCode.OK;
                    response.Content = new StreamContent(fileInfo.ReadStream());
                    response.Content.Headers.Add("x-filename", fileInfo.Name);
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                    response.Content.Headers.ContentDisposition.FileName = filename;
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    response.Content.Headers.ContentLength = fileInfo.Length;
                }
            }
            catch (Exception exception)
            {
                // Log exception and return gracefully
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, "", new MediaTypeHeaderValue("text/json"));
            }
            return response;
        }

        [Route("files")]
        [HttpPost]
        public HttpResponseMessage UploadFile()
        {
            var content = Request.Content;
            return null;
        }
    }
}
