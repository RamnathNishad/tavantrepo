using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPCoreMVC.Models
{

    [Table("employee")]
    public class Employee
    {
        [Key]
        [Column("ecode")]
        public int Ecode { get; set; }

        [Column("ename")]
        public string Ename { get; set; }

        [Column("salary")]
        public int Salary { get; set; }

        [Column("deptid")]
        public int Deptid { get; set; }

        public static List<Employee> employees = new List<Employee>
        {
            new Employee{Ecode=101,Ename="Ravi",Salary=1111,Deptid=201},
            new Employee{Ecode=102,Ename="Rahul",Salary=2222,Deptid=202},
            new Employee{Ecode=103,Ename="Raju",Salary=3333,Deptid=203},
            new Employee{Ecode=104,Ename="Naveen",Salary=4444,Deptid=202},
            new Employee{Ecode=105,Ename="Suresh",Salary=5555,Deptid=201}
        };
    }
}
