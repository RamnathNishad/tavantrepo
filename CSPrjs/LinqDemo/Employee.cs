using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    internal class Employee
    {
        public int Ecode {  get; set; }
        public string Ename { get; set; }
        public int Salary { get; set; }
        public int Deptid {  get; set; }

        public static List<Employee> GetEmps()
        {
            return new List<Employee>
            {
                new Employee{Ecode=101,Ename="Ravi",Salary=20000,Deptid=201 },
                new Employee{Ecode=102,Ename="Rakesh",Salary=40000,Deptid=202 },
                new Employee{Ecode=103,Ename="Rahul",Salary=30000,Deptid=202 },
                new Employee{Ecode=104,Ename="Rohit",Salary=25000,Deptid=203 },
                new Employee{Ecode=105,Ename="Neeraj",Salary=50000,Deptid=201 }
            };
        }
    }
}
