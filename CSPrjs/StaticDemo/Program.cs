namespace StaticDemo
{
    internal class Program
    {
        int non_static;
        static int static_var;
        static void Main(string[] args)
        {
            static_var = 100;
            Demo obj=new Demo();
            //obj.s=100; //invalid
            Demo.s = 100; //valid

        }
        void Test()
        {
            non_static = 0;
            static_var = 0;
        }

       

    }
    class Demo
    {
        public static int s = 100;

    }
}
