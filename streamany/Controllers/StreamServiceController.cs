using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using streamany.Models;

namespace streamany.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class StreamServiceController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;
        private readonly streamanyContext _streamanyContext;

        public StreamServiceController(IHostingEnvironment hostingEnvironment, streamanyContext streamanyContext)
        {
            _hostingEnvironment = hostingEnvironment;
            _streamanyContext = streamanyContext;
        }

        [HttpPost]
        [Route("/api/upload")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var file = Request.Form.Files[0];
                if (file.Length > 0)
                {

                    byte[] data = new byte[file.Length];
                    file.OpenReadStream().Read(data);

                    _streamanyContext.File.Add(new Models.File
                    {
                        FileAsByte = data,
                        FileContentType = file.ContentType,
                        FileExtension = System.IO.Path.GetExtension(file.Name),
                        FileName = file.FileName
                    });

                    await _streamanyContext.SaveChangesAsync();
                }
                return Json("Upload Successful.");
            }
            catch (Exception ex)
            {
                return Json("Upload Failed: " + ex.Message);
            }
        }

        [Route("/file/{fileName}")]
        public async Task<IActionResult> GetFile([FromRoute] string fileName)
        {
            var file = await _streamanyContext.File.Where(a => a.FileName == fileName).Select(b => b).FirstOrDefaultAsync();

            if (file.FileAsByte == null)
            {
                return NotFound();
            }

            return File(file.FileAsByte, file.FileContentType);
        }
    }
}