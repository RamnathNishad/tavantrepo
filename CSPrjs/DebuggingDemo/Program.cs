namespace DebuggingDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int salary = 4000;
            double bonus = 0;
            Employee employee = new Employee();
            bonus = employee.GetBonus(salary);
            Console.WriteLine($"Salary:{salary}\tBonus:{bonus}");
        }
    }

    class Employee
    {
        public double GetBonus(int salary)
        {
            double bonus;
            if (salary > 5000)
                bonus = 0.1 * salary;
            else
                bonus = 0.2 * salary;
            
            
            return bonus;
        }
    }
}
