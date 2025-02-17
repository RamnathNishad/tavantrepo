using ADOLib; //for Data Access Layer

namespace ADOClientConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("1.Add employee");
                Console.WriteLine("2.Delete employee");
                Console.WriteLine("3.Update employee");
                Console.WriteLine("4.Display employees");
                Console.WriteLine("5.Find employee by id");
                Console.WriteLine("0.Exit");
                Console.Write("Enter choice:");
                choice=int.Parse(Console.ReadLine());

                //AdoDisconnected dal = null;
                AdoConnected dal = null;
                switch (choice)
                {
                    case 1:
                        //Add employee
                        try
                        {
                            //take user input for insert
                            var emp = new Employee();
                            Console.Write("Enter ecode:");
                            emp.Ecode = int.Parse(Console.ReadLine());
                            Console.Write("Enter ename:");
                            emp.Ename = Console.ReadLine();
                            Console.Write("Enter salary:");
                            emp.Salary = int.Parse(Console.ReadLine());
                            Console.Write("Enter deptid:");
                            emp.Deptid = int.Parse(Console.ReadLine());
                            //insert using DAL
                            dal = new AdoConnected();
                            //dal = new AdoDisconnected();
                            dal.AddEmployee(emp);
                            Console.WriteLine("Record inserted");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 2:
                        //Delete employee
                        try
                        {
                            Console.Write("Enter ecode for delete:");
                            int ec = int.Parse(Console.ReadLine());
                            dal = new AdoConnected();
                            //dal=new AdoDisconnected();
                            dal.DeleteEmployee(ec);
                            Console.WriteLine("Record deleted");
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 3:
                        //Update employee
                        try
                        {
                            //take user input for update
                            var emp = new Employee();
                            Console.Write("Enter ecode:");
                            emp.Ecode = int.Parse(Console.ReadLine());
                            Console.Write("Enter ename:");
                            emp.Ename = Console.ReadLine();
                            Console.Write("Enter salary:");
                            emp.Salary = int.Parse(Console.ReadLine());
                            Console.Write("Enter deptid:");
                            emp.Deptid = int.Parse(Console.ReadLine());
                            //update using DAL
                            dal = new AdoConnected();
                            //dal = new AdoDisconnected();
                            dal.UpdateEmployee(emp);
                            //dal.UpdateSalUsingSP(emp.Ecode, emp.Salary);
                            Console.WriteLine("Record updated");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 4:
                        //Display all employees
                        dal = new AdoConnected();
                        //dal = new AdoDisconnected();
                        var lstEmps = dal.GetAllEmployees();
                        if (lstEmps.Count == 0)
                        {
                            Console.WriteLine("No records available");
                        }
                        else
                        {
                            foreach (var e in lstEmps)
                            {
                                Console.WriteLine($"{e.Ecode}\t{e.Ename}\t{e.Salary}\t{e.Deptid}");
                            }
                        }
                        break;
                    case 5:
                        //Find by id
                        try
                        {
                            Console.Write("Enter ecode for search:");
                            int ec = int.Parse(Console.ReadLine());
                            dal = new AdoConnected();
                            //dal = new AdoDisconnected();
                            var emp=dal.GetEmployee(ec);
                            if(emp==null)
                            {
                                Console.WriteLine("Record not found");
                            }
                            else
                            {
                                Console.WriteLine($"{emp.Ecode}\t{emp.Ename}\t{emp.Salary}\t{emp.Deptid }");
                            }                            
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 0:
                        Console.WriteLine("Exitded...");
                        break;
                    default:
                        Console.WriteLine("invalid choice");
                        break;
                }
            } while (choice != 0);
        }
    }
}
