using Microsoft.AspNetCore.Mvc;
using MVCAPIClient.Models;
using System.Diagnostics;

namespace MVCAPIClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
             
            string token = HttpContext.Session.GetString("token");
            if (token == null)
            {
                //send user to login page to get token
                return RedirectToAction("Login","Account");
            }
            else
            {
                try
                {
                    List<Employee> lstEmps = ApiConsumer.GetEmps(token); //get from API
                    return View(lstEmps);
                }
                catch (Exception ex)
                {
                    ViewData.Add("errMsg", ex.Message);
                    return View("Error");
                }
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            string token= HttpContext.Session.GetString("token");
            if (token != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }            
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            string token=HttpContext.Session.GetString("token");
            if (token != null)
            {
                //call the API AddEmp
                string msg= ApiConsumer.AddEmp(emp, token);
                if(msg==null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData.Add("errMsg", msg);
                    return View("Error");
                }                
            }
            return RedirectToAction("Login","Account");
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
