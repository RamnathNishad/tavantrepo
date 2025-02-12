namespace OverloadingDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sum:"+Util.Add(10,20));
            Console.WriteLine("Sum:" + Util.Add(10,20,30));
            Console.WriteLine("Sum:" + Util.Add(10.5,5.3));
        }
    }

    class Util
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }
        public static int Add(int x, int y,int z)
        {
            return x + y + z;
        }
        public static double Add(double x, double y)
        {
            return x + y;
        }
        //public static string Add(int a, int b)
        //{
        //    return "Hello";
        //}
    }
}
