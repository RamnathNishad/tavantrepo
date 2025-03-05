using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesWebApi.Models
{
    [Table("resumes")]
    public class Resume
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")] 
        public string Name { get; set; }
        
        [Column("docfile")] 
        public byte[] FileData { get; set; } 
    }
}
