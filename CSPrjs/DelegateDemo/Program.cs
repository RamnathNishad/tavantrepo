namespace DelegateDemo
{
    internal class Program
    {
        //declare the delegate
        delegate int CalculateDelegate(int a, int b);
        static void Main(string[] args)
        {
            NumericCalcultor obj = new NumericCalcultor();

            //binding
            CalculateDelegate dlg = new CalculateDelegate(obj.Add);

            //invoke
            //int result = dlg(100, 200);
            //Console.WriteLine("Sum:" + result);

            dlg+=new CalculateDelegate(obj.Subtract);
            int result = dlg(100, 200);
            Console.WriteLine("Difference:" + result);
            
            dlg=new CalculateDelegate(delegate (int a, int b)
                                                {
                                                    Console.WriteLine("multiply is called");
                                                    return a * b;
                                                });

            Console.WriteLine("Multiply:" + dlg(10, 5));

            //Lambda expression
            dlg = new CalculateDelegate( (a,b)=>
            {
                Console.WriteLine("division is called");
                return a / b;
            });

            Console.WriteLine("Multiply:" + dlg(10, 5));

            Demo demo = new Demo();
            demo.StartTask();

            Func<int, int, int> d2 = new Func<int, int, int>(obj.Add);
            Console.WriteLine(d2(10,20));

            Func<string, string, string> d3 = new Func<string, string, string>(StringManipulator.AddString);
            Console.WriteLine(d3("Hello","World"));
        }
    }

    class NumericCalcultor
    {
        public int Add(int a, int b)
        {
            Console.WriteLine("Add is called");
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            Console.WriteLine("Subtract is called");
            return a - b;
        }
    }
    class StringManipulator
    {
        public static string AddString(string s1, string s2)
        {
            return s1 + " " + s2;
        }        
    }

    class Demo
    {
        private void Notify(string msg)
        {
            Console.WriteLine(msg);
        }
        public void StartTask()
        {
            Consumer c = new Consumer();
            c.dlg+=new Consumer.MsgDelegate(Notify);
            c.Test();
            //c.dlg("done");
        }
    }
    class Consumer
    {
        public delegate void MsgDelegate(string msg);
        public event MsgDelegate dlg = null;
        public void Test()
        {
            Console.WriteLine("Tast initiated");
            dlg("task is finished"); //invoking private callback method
        }
    }
}
