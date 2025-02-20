using Microsoft.AspNetCore.Mvc;

namespace ASPCoreMVC.Controllers
{
    public class SecondController : Controller
    {
        public IActionResult Index()
        {
            ViewData.Add("y", Request.HttpContext.Session.GetInt32("y"));

            var company = Request.Cookies["company"];
            ViewData.Add("company", company);
            
            return View();
        }
    }
}
