using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesWebApi.Models
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        [Column("ecode")]
        public int Ecode {  get; set; }

        [Column("ename")]
        public string Ename { get; set; }

        [Column("salary")]
        public int Salary { get; set; }

        [Column("deptid")]
        public int Deptid { get; set; }
    }
}
