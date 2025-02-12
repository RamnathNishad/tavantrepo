namespace ConstructorAndDestructorDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee(101, "Ravi", 1111);
            Console.WriteLine(emp.ToString());
            Employee emp2 = new Employee(102, "Rahul", 2222);
            Console.WriteLine(emp2.ToString());

            Employee emp3 = new Employee(103, "Rohit", 3333);
            Console.WriteLine(emp3.ToString());

        }
    }

    class Employee
    {
        int ecode;
        string ename;
        int salary;
        static string companyName;

        public Employee(int ecode,string ename,int salary)
        {
            this.ecode = ecode;
            this.ename = ename;
            this.salary = salary;            
            Console.WriteLine("constructor is called");
        }
        static Employee()
        {
            Employee.companyName = "Tavant";
            Console.WriteLine("static ctor called");
        }
        public override string ToString()
        {
            return $"{ecode}\t{ename}\t{salary}\t{companyName}";
        }
    }
}
