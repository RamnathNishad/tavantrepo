using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Enhancements
{
    internal partial class Demo
    {
        public ref int  Method1(out int a,ref int b) {
            a = 100;
            Console.WriteLine($"a:{a}\tb:{b}");

            return ref b;
        }
    }

    internal partial class Demo
    {
        int ecode;
        //public int Ecode { get { return ecode; } }
        public int Ecode=> ecode;


        //public int Method2(int x) { return x * x; }
        public int Method2(int x) => x * x;
        
        //default property initializer
        public int Salary { get; set; } = 5000;


        public (int a,int b) GetData()
        {
            int c = 100;
            (int x,int y) getNumbers()
            {
                return (100,c);
            }

            var data = getNumbers();

            return data;
        }
    }


    interface ISome
    {
        void task1();
        void task2() { }
    }

    class Child1 : ISome
    {
        public void task1()
        {
            throw new NotImplementedException();
        }
        public void task2()
        {
            throw new NotImplementedException();
        }
    }
    class Child2 : ISome
    {
        public void task1()
        {
            throw new NotImplementedException();
        }
    }
}
