using ASPCoreMVC.Models;
using EFRelationShipsDemo;
using Microsoft.AspNetCore.Authentication.Cookies;
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

            builder.Services.AddDbContext<SampleDbContext>(options =>
            options.UseNpgsql("Host=localhost;Database=sampledb;Username=postgres;Password=sa;Persist Security Info=True")
            );

            //configure dependency injection for DataAccess component
            builder.Services.AddScoped<IEmployeeDataAccess,EmployeeDataAccess>();

            builder.Services.AddSession();

            //add authentication and authorization middleware
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy =>
                {
                    policy.RequireRole("Admin");
                });                
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (!app.Environment.IsDevelopment())
            //{
            //    app.UseExceptionHandler();
            //}
            //else
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseMiddleware<CustomException>();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employees}/{action=Index}/{id?}");

           

            app.UseSession();

            app.Run();
        }
    }
}
