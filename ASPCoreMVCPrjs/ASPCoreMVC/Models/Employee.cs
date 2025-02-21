using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPCoreMVC.Models
{

    [Table("employee")]
    public class Employee
    {
        [Key]
        [Column("ecode")]
        [Required]
        [RegularExpression(@"\d{3,3}",ErrorMessage ="ecode must be exactly 3-digits")]
        public int Ecode { get; set; }

        [Column("ename")]
        [Required]
        [StringLength(10)]        
        public string Ename { get; set; }

        [Column("salary")]
        [Required]
        [Range(500,20000)]
        public int Salary { get; set; }

        [Column("deptid")]
        [Required]
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
