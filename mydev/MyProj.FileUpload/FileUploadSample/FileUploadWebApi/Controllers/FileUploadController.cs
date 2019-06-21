using System;
using System.IO;
using FileUploadWebApi.Models;
using Microsoft.AspNetCore.Mvc;
namespace FileUploadWebApi.Controllers
{
    [Route("api/[controller]")]
    public class FileUploadController:Controller
    {
        const string FILE_PATH = @"D:\Samples\";
        [HttpPost]
        public IActionResult Post([FromBody]FileUploadModel theFile){
            return Ok();
        }
    }
}