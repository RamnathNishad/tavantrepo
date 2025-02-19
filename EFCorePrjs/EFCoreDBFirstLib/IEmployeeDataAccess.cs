using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDBFirstLib
{
    public interface IEmployeeDataAccess
    {
        void Add(Employee employee);
        void Delete(int id);
        void UpdateEmployee(Employee employee);
        List<Employee> GetAllEmps();
        Employee GetEmpById(int id);
    }
}
