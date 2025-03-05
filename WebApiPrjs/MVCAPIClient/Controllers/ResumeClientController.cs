using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MVCAPIClient.Controllers
{
    [Route("ResumeClient")]
    public class ResumeClientController : Controller
    {
        [HttpGet]
        [Route("Upload")]
        public IActionResult Upload()
        {
            //it is for using in download link in the view,
            //its value will be provided from DB record or user input
            ViewData.Add("fileName", "dotnetPPTs.ppt"); 

            return View();
        }
        [HttpPost]
        [Route("Upload")]
        public IActionResult Upload(IFormFile file)
        {
            var http=new HttpClient();

            var memoryStream = new MemoryStream();
            file.CopyToAsync(memoryStream);

            var fileContent = new ByteArrayContent(memoryStream.ToArray());
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");

            var content = new MultipartFormDataContent();
            content.Add(fileContent, "file", file.FileName);

            var res = http.PostAsync("http://localhost:5005/api/Resume/upload", content);
            res.Wait();
            var response = res.Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.Message = "File uploaded successfully!";
            }
            else
            {
                ViewBag.Message = "Upload failed.";
            }

            ViewData.Add("fileName", "dotnetPPTs.ppt");
            return View();
        }
        [Route("download/{fileName}")]
        public IActionResult Download(string fileName)
        {
            var http = new HttpClient();
            var apiUrl = $"http://localhost:5005/api/Resume/download/{fileName}";
            var res = http.GetAsync(apiUrl);
            var response = res.Result;

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Message = "File not found.";
                return View();
            }

            var bytes = response.Content.ReadAsByteArrayAsync();
            bytes.Wait();

            var fileBytes = bytes.Result;

            var contentType = response.Content.Headers.ContentType?.ToString() ?? "application/octet-stream";

            return File(fileBytes, contentType, fileName);
        }
    }
}
