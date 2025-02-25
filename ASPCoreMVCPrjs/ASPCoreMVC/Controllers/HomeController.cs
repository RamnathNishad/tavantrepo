using Microsoft.AspNetCore.Mvc;

namespace ASPCoreMVC.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        [Route("Error/{errMsg?}")]
        public IActionResult Error(string errMsg)
        {
            ViewData.Add("errorMsg", errMsg);
            return View();
        }
    }
}
