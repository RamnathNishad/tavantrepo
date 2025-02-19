using EFCoreDBFirstLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BusinessLayerHRMSLib
{
    public class BusinessLayer
    {
        private readonly IEmployeeDataAccess dal;
        public BusinessLayer(IEmployeeDataAccess dal)
        {
            this.dal = dal;
        }
        public List<Employee> GetEmps()
        {
            return dal.GetAllEmps();
        }
        public Employee GetEmployee(int id)
        {
            return dal.GetEmpById(id);
        }
        public void AddEmployee(Employee emp)
        {
            dal.Add(emp);
        }
        public void DeleteEmp(int ecode)
        {
            dal.Delete(ecode);
        }
        public void UpdateEmployee(Employee emp)
        {
            dal.UpdateEmployee(emp);
        }
    }
}
