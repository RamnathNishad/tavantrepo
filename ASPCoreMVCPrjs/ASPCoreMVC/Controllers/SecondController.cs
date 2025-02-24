using ASPCoreMVC.Models;
using EFRelationShipsDemo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPCoreMVC.Controllers
{
    public class SecondController : Controller
    {
        private readonly SampleDbContext db;
        public SecondController(SampleDbContext db)
        {
            this.db= db;
        }
        public IActionResult Index()
        {
            ViewData.Add("y", Request.HttpContext.Session.GetInt32("y"));

            var company = Request.Cookies["company"];
            ViewData.Add("company", company);
            
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var customerVM = new Models.CustomerVM
            {
                Cities=new List<SelectListItem>
                {
                    new SelectListItem{Text="Delhi",Value="DLI"},
                    new SelectListItem{Text="Mysore",Value="MYS"},
                    new SelectListItem{Text="Bangalore",Value="BLR"},
                    new SelectListItem{Text="Hyderabad",Value="HYD"},
                    new SelectListItem{Text="Jaipur",Value="JPR"}
                },
                Languages=new List<string>
                {
                    "English","Kanada","Hindi"
                }
            };
            return View(customerVM);
        }
        [HttpPost]
        public IActionResult Create(Models.Customer customer)
        {
            return View("DisplayDetails",customer);
        }
    }
}
