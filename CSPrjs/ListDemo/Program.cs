using System.Collections.Generic;
using System.Collections;
using System.Runtime.Intrinsics.Arm;

namespace ListDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            numbers.Add(20);
            numbers.Add(10);
            numbers.Add(30);
            numbers.Add(50);
            numbers.Add(40);

            numbers.Sort();

            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }


            List<Employee> lstEmps=new List<Employee>();
            lstEmps.Add(new Employee { Ecode = 102, Ename = "Rahul", Salary = 2222, Deptid = 202 });
            lstEmps.Add(new Employee {Ecode=101,Ename="Ravi",Salary=2222,Deptid=201 });
            lstEmps.Add(new Employee { Ecode = 103, Ename = "Rohit", Salary = 3333, Deptid = 203 });
            
            lstEmps.Sort(new SortBySalary());

            foreach (Employee e in lstEmps)
            {
                //Console.WriteLine(e.ToString());
                if (e.Ecode == 101)
                {
                    //lstEmps.Remove(e);//invalid
                }
            }

            for (int i = 0; i < lstEmps.Count; i++)
            {
                if (lstEmps[i].Ecode == 102)
                {
                    //lstEmps.RemoveAt(i);
                }
                else
                {
                    //Console.WriteLine(lstEmps[i].ToString());
                }
                }

            IEnumerator<Employee> ien= lstEmps.GetEnumerator();
            while (ien.MoveNext())
            {
                Console.WriteLine(ien.Current.ToString());
            }

            string s1 = "Hello";
            string s2 = "Hello";
            Console.WriteLine(s1.CompareTo(s2));
        }
    }
}
