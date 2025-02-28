using EmployeesWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
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
        [Authorize(Roles = "Admin,Guest")]
        public IActionResult GetAllEmps()
        {
            //int a = 10, b = 0;
            //int res = a / b;


            try
            {
                return Ok(dal.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET api/<EmployeesController>/5
        [HttpGet]
        [Route("GetEmpById/{id}")]
        public IActionResult GetEmpById(int id)
        {
            try
            {
                return Ok(dal.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<EmployeesController>
        [HttpPost]
        [Route("AddEmp")]
        //[Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] Employee employee)
        {
            if(employee.Ename.IsNullOrEmpty())
            {
                ModelState.AddModelError("ename", "ename must not be empty");
            }


            try
            {
                if (ModelState.IsValid)
                {
                    dal.Add(employee);
                    return Ok("Record inserted");
                }
                else
                {
                    throw new Exception("ename must not be empty"); ;
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }           
           
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
        public IActionResult DeleteById(int id)
        {
            try
            {
                dal.Delete(id);
                return Ok("Record deleted");
            }
            catch (Exception ex)
            {
                //log the ex details and send custom msg
                return BadRequest(ex.Message);
            }           
        }
    }
}
