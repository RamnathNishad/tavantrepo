﻿
namespace OutvsRef
{
    internal class Program
    {   

        static void Main(string[] args)
        {
            int salary = 4000;
            double bonus = 0;

            Console.WriteLine($"Before: Salary:{salary}\tBonus:{bonus}");
            CalculateBonus( salary, out bonus );
            Console.WriteLine($"After: Salary:{salary}\tBonus:{bonus}");
        }

        static void CalculateBonus(int salary, out double bonus)
        {
            if (salary > 5000)
            {
                bonus = salary * 0.1;
            }
            else
            {
                bonus = salary * 0.2;
            }
        }
    }


    //class Demo
    //{
    //    //int x = 100;
    //    string name = "ravi";

    //    public static void DisplayX(int x)
    //    {
    //        Console.WriteLine("X:"+x);
    //    }
    //    public void DisplayName()
    //    {
    //        Console.WriteLine("Name:"+name);
    //    }
    //}
}
