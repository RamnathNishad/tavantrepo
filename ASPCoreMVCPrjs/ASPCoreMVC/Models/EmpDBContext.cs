using Microsoft.EntityFrameworkCore;

namespace ASPCoreMVC.Models
{
    public class EmpDBContext : DbContext
    {
        public EmpDBContext(DbContextOptions<EmpDBContext> opts)
            : base(opts)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
      
    }
}
