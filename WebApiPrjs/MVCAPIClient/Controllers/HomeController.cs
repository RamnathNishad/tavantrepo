using Microsoft.AspNetCore.Mvc;
using MVCAPIClient.Models;
using System.Diagnostics;

namespace MVCAPIClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Employee> lstEmps = ApiConsumer.GetEmps(); //get from API
            return View(lstEmps);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            //call the API AddEmp
            ApiConsumer.AddEmp(emp);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //call the API to get by id
            var emp=ApiConsumer.GetEmpById(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            //call the API to Update Employee
            var status = ApiConsumer.UpdateEmp(emp);
            if (status)
            {
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
            ApiConsumer.DeleteEmployee(id);
           return RedirectToAction("Index");        
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var emp=ApiConsumer.GetEmpById(id);
            return View(emp);
        }
    }
}
