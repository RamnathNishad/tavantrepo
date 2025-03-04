using EmployeesWebApi.Models;
using EmployeesWebApi.Controllers;
using Moq;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace TestProject1
{
    public class UnitTestEmployeeApi
    {
        private readonly Mock<IEmployeeDataAccess> dal;
        private readonly EmployeesController api;
        public UnitTestEmployeeApi()
        {
            dal=new Mock<IEmployeeDataAccess>();
            api=new EmployeesController(dal.Object);
        }


        [Fact]
        public void GetEmpByIdTest()
        {
            //Arrange
            var ecode = 101;
            var expectedEmp = new Employee { Ecode=101,Ename="Ravi",Salary=1111,Deptid=201};
            dal.Setup(s => s.Get(ecode)).Returns(expectedEmp);

            //Act
            var result =(OkObjectResult)api.GetEmpById(ecode);

            //Assert
            Assert.Equal(expectedEmp, result.Value);
        }

        [Fact]
        public void GetEmpById_NotFound_Test()
        {   

        }

        [Fact]
        public void AddEmployee_Test()
        {
            //Arrange
            var emp = new Employee
            {
                Ecode=301,
                Ename="RRR",
                Salary=3434,
                Deptid=201
            };
            dal.Setup(s => s.Get(emp.Ecode)).Returns(emp);

            //Act
            var okResult =(OkObjectResult)api.AddEmp(emp);
            var okResult2 = (OkObjectResult)api.GetEmpById(emp.Ecode);
            //Assert
            Assert.IsType<OkObjectResult>(okResult);
            Assert.IsType<OkObjectResult>(okResult2);
            
        }
    }
}