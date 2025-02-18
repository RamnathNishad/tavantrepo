namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //SRP
            //Employee emp=new Employee
            //{
            //    Ecode=101,
            //    Ename="ravi",
            //    Salary=7000
            //};
            //emp.Display();

            //OCP
            AreaCalculator calculator = new AreaCalculator();
            double area = 0;
            Console.WriteLine("Area of shapes");
            Console.WriteLine("1.Square");
            Console.WriteLine("2.Circle");
            Console.Write("Enter choice:");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Square square = new Square
                    {
                        Side = 10
                    };
                    area = calculator.CalculateArea(square);
                    Console.WriteLine($"Area of Square:{area}");
                    break;
                case 2:
                    Circle circle = new Circle
                    {
                        Radius = 5
                    };
                    area = calculator.CalculateArea(circle);
                    Console.WriteLine($"Area of Circle:{area}");
                    break;
            }

        }
    }


    class Employee
    {
        public int Ecode { get; set; }
        public string Ename { get; set; }
        public int Salary { get; set; }

        public void Display()
        {            
            Console.WriteLine($"{Ecode}\t{Ename}\t{Salary}\t{GetBonus()}");
        }
        double GetBonus()
        {
            double bonus = 0;
            if (Salary > 5000)
            {
                bonus = 0.1 * Salary;
            }
            else
            {
                bonus = 0.2 * Salary;
            }
            return bonus;
        }
    }
}
