using EmployeesWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.IO;
using System.Xml.Linq;

namespace EmployeesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly EmployeeDbContext dbCtx;
        public ResumeController(EmployeeDbContext dbCtx)
        {
            this.dbCtx = dbCtx;
        }
        [HttpPost]
        [Route("upload")]
        public IActionResult UploadResume(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            file.CopyToAsync(memoryStream);
            byte[] fileBytes = memoryStream.ToArray();
    
            var resume = new Resume
            {
                Name = file.FileName,
                FileData = fileBytes
            };
            dbCtx.Resumes.Add(resume);
            dbCtx.SaveChanges();

            return Ok("Resume uploaded successfully");
        }
        [HttpGet]
        [Route("download/{fileName}")]
        public IActionResult DownloadResume(string fileName)
        {
            var resume = dbCtx.Resumes.FirstOrDefault(d => d.Name == fileName);

            if (resume != null)
            {
                return File(resume.FileData, "application/octet-stream", resume.Name);
            }
            else
            {
                return NotFound("File not found,could not download");
            }
        }
    }
}
