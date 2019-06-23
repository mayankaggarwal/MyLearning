using System;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
namespace FileUploadWebApi.Controllers
{
   [Route("api/[controller]")]
    public class UploadController:Controller
    {
        const string FILE_PATH = @"D:\Samples\";

        [HttpPost]
        public ActionResult Post()
        {
            try
            {
                var file = Request.Form.Files[0];
                string folderName = "Upload";
                string webRootPath = FILE_PATH;
                string newPath = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }

                if (file.Length > 0)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    fileName = Path.GetFileName(fileName);
                    string fullPath = Path.Combine(newPath, fileName);
                    using(var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return Ok("Uploaded Successfully");
            }
            catch(Exception exp)
            {
                return Ok("Upload Failed: " + exp.Message);
            }
        }
    }
}