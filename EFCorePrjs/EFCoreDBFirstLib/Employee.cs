using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDBFirstLib
{
    //[Table("tbl_name")]
    public class Employee
    {
        [Key]
        public int ecode { get; set; }
        public string ename { get; set; }
        public int salary { get; set; }
        public int deptid {  get; set; }
    }
}
