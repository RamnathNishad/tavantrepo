using EmployeesWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeDataAccess dal;
        public EmployeesController(IEmployeeDataAccess dal)
        {
            this.dal = dal;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        [Route("GetAllEmps")]
        public IEnumerable<Employee> GetAllEmps()
        {
            return dal.GetAll();
        }


        // GET api/<EmployeesController>/5
        [HttpGet]
        [Route("GetEmpById/{id}")]
        public Employee GetEmpById(int id)
        {
            return dal.Get(id);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        [Route("AddEmp")]
        public void Post([FromBody] Employee employee)
        {
            dal.Add(employee);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut]
        [Route("UpdateEmp/{id}")]
        public void UpdateEmp(int id, [FromBody] Employee emp)
        {
            dal.Update(emp);
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete]
        [Route("DeleteById/{id}")]
        public void DeleteById(int id)
        {
            dal.Delete(id);
        }
    }
}
