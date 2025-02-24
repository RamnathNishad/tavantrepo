using System.ComponentModel.DataAnnotations.Schema;

namespace EFRelationShipsDemo
{
    public class Student
    {
        public int Id { get; set; }
        public string Sname { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }
    }
}
