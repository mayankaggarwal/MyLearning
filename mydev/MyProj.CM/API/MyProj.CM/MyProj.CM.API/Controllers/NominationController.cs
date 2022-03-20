using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using MyProj.CM.API.Helper;

namespace MyProj.CM.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NominationController : ControllerBase
    {
        private static readonly FormOptions DefaultFormOptions = new FormOptions();
        [Filters.CustomAuthorize("OfferManager:Nominations::Manage")]
        [HttpPost,Route("uploadnominations")]
        public async Task<IActionResult> UploadNominations(IFormFile file)
        {
            if (file == null || !MultiPartFileHelper.IsMultipartContentType(Request.ContentType)
                || !MultiPartFileHelper.IsExtensionAllowed(file.FileName, MultiPartFileHelper.CsvExtension))
                return BadRequest(HttpStatusCode.UnsupportedMediaType);

            string data = await file.ReadAsStringAsync();


            return Ok();
        }

        [RequestSizeLimit(1073741824)]
        [Filters.DisableFormValueModelBinding]
        [Filters.CustomAuthorize("OfferManager:Nominations::Manage")]
        [HttpPost, Route("{id:int}/attachments/upload")]
        public async Task<IActionResult> UploadNewAttachment(int id)
        {
            if (!MultiPartFileHelper.IsMultipartContentType(Request.ContentType)){
                return BadRequest(HttpStatusCode.UnsupportedMediaType);
            }

            var boundary = MultiPartFileHelper.GetBoundary(MediaTypeHeaderValue.Parse(Request.ContentType),
                DefaultFormOptions.MultipartBoundaryLengthLimit);
            var reader = new MultipartReader(boundary, HttpContext.Request.Body);
            var section = await reader.ReadNextSectionAsync();
            var fileNme = string.Empty;
            if (section != null)
            {
                var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(
                section.ContentDisposition, out var contentDisposition);

                if (hasContentDispositionHeader)
                {
                    if (MultiPartFileHelper.HasFileContentDisposition(contentDisposition))
                    {
                        fileNme = contentDisposition.FileName.Value?.Replace("\"","");
                    }
                }
            }
            if(string.IsNullOrWhiteSpace(fileNme) || !MultiPartFileHelper.IsExtensionAllowed(fileNme, ""))
            {
                return BadRequest();
            }

            if (Request.ContentLength != null)
            {
                // register initiation in db
                //var fileUploadResult = await _storageClient.UploadFileAsync(fileInfo, section?.Body, CancellationToken.None);
                // register completion in db
            }

            return Ok();
        }
    }
}