using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstLib
{
    public class CustomerDBContext : DbContext
    {
        //public CustomerDBContext(DbContextOptions<CustomerDBContext> options)
        //    :base(options)
        //{

        //}
        public CustomerDBContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host=localhost;Database=empdb;Username=postgres;Password=sa;Persist Security Info=True");
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
