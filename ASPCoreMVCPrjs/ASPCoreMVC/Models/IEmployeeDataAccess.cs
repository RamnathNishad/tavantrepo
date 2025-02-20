﻿namespace ASPCoreMVC.Models
{
    public interface IEmployeeDataAccess
    {
        void AddEmployee(Employee employee);
        void DeleteEmployee(int id);
        void UpdateEmployee(Employee employee);
        List<Employee> GetAllEmps();
        Employee GetEmpById(int id);
    }
}
