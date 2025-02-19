using BusinessLayerHRMSLib;
using EFCoreDBFirstLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EFCoreConsole
{
    internal class Program
    {       
        static void Main(string[] args)
        {
            //configure dependency injection service for DAL and Context
            var depServices = new ServiceCollection();
            depServices.AddDbContext<EmpDBContext>(options =>
            {
                options.UseNpgsql("Host=localhost;Database=empdb;Username=postgres;Password=sa;Persist Security Info=True");
            });
            depServices.AddScoped<IEmployeeDataAccess,EmployeeDataAccess>();

            //get the DAL instance from service provider
            var provider=depServices.BuildServiceProvider();
            var dal=provider.GetService<IEmployeeDataAccess>();


            BusinessLayer bll = new BusinessLayer(dal);
           
            int choice = 0;
            do
            {
                Employee emp = null;
                DisplayMenu();
                choice=int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        try
                        {
                            //Add employee
                            emp = new Employee();
                            Console.Write("Enter ecode:");
                            emp.ecode = int.Parse(Console.ReadLine());
                            Console.Write("Enter ename:");
                            emp.ename = Console.ReadLine();
                            Console.Write("Enter salary:");
                            emp.salary = int.Parse(Console.ReadLine());
                            Console.Write("Enter deptid:");
                            emp.deptid = int.Parse(Console.ReadLine());
                            //insert record using business layer
                            bll.AddEmployee(emp);
                            Console.WriteLine("Record inserted");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 2:
                        //delete emp by id
                        try
                        {
                            Console.Write("Enter ecode for delete:");
                            int ec = int.Parse(Console.ReadLine());
                            bll.DeleteEmp(ec);
                            Console.WriteLine("Record deleted");
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 3:
                        //update employee
                        try
                        {
                            emp = new Employee();
                            Console.Write("Enter ecode:");
                            emp.ecode = int.Parse(Console.ReadLine());
                            Console.Write("Enter ename:");
                            emp.ename = Console.ReadLine();
                            Console.Write("Enter salary:");
                            emp.salary = int.Parse(Console.ReadLine());
                            Console.Write("Enter deptid:");
                            emp.deptid = int.Parse(Console.ReadLine());
                            //update record using business layer
                            bll.UpdateEmployee(emp);
                            Console.WriteLine("Record updated");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 4:
                        //display employees
                        var lstEmps = bll.GetEmps();
                        foreach (var e in lstEmps)
                        {
                            Console.WriteLine($"{e.ecode}\t{e.ename}\t{e.salary}\t{e.deptid}");
                        }
                        break;
                    case 5:
                        //find by id
                        try
                        {
                            Console.Write("Enter ecode:");
                            int ecode = int.Parse(Console.ReadLine());
                            var record = bll.GetEmployee(ecode);
                            Console.WriteLine($"{record.ecode}\t{record.ename}\t{record.salary}\t{record.deptid}");
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 0:
                        //exit
                        Console.WriteLine("Exited...");
                        break;
                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }
            } while (choice != 0);


            

        }
        static void DisplayMenu()
        {
            Console.WriteLine("1.Add employee");
            Console.WriteLine("2.Delete employee");
            Console.WriteLine("3.Update employee");
            Console.WriteLine("4.Display all employees");
            Console.WriteLine("5.Find employee");
            Console.WriteLine("0.Exit");
            Console.Write("Enter choice:");
        }
    }
}
