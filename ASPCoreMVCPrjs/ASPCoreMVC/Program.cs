using ASPCoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //configure dependency injection for DbContext 
            builder.Services.AddDbContext<EmpDBContext>(opts =>
                opts.UseNpgsql("Host=localhost;Database=empdb;Username=postgres;Password=sa;Persist Security Info=True")
            );

            //configure dependency injection for DataAccess component
            builder.Services.AddScoped<IEmployeeDataAccess,EmployeeDataAccess>();

            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employees}/{action=Index}/{id?}");

            app.UseSession();

            app.Run();
        }
    }
}
