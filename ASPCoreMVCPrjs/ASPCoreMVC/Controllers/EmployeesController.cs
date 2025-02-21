using ASPCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreMVC.Controllers
{   
    public class EmployeesController : Controller
    {
        private readonly IEmployeeDataAccess dal;
        public EmployeesController(IEmployeeDataAccess dal)
        {
            this.dal = dal;
        }
        public IActionResult Index()
        {
            ViewData.Add("heading", "Employee Management Application");

            ViewBag.Message = "Hello";

            TempData.Add("x", 100);

            Request.HttpContext.Session.SetInt32("y", 200);

            Response.Cookies.Append("company", "Tavant");


            return View(dal.GetAllEmps());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if(dal.GetEmpById(emp.Ecode)!=null)
            {
                ModelState.AddModelError("Ecode", "duplicate ecode");
            }

            if (ModelState.IsValid)
            {
                dal.AddEmployee(emp);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var record = dal.GetEmpById(id);
            if(record!=null)
            {
                dal.DeleteEmployee(record.Ecode);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var record = dal.GetEmpById(id);
            return View(record);
        }

        [HttpGet]        
        public IActionResult Edit(int id)
        {
            var record=dal.GetEmpById(id);
            return View(record);
        }
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            dal.UpdateEmployee(emp);
            return RedirectToAction("Index");
        }
    }
}
