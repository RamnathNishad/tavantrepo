namespace ExtensionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            //x.Square();
            Console.WriteLine($"square of {x} is {x.Square()}");
            int y = 5;

            Console.WriteLine($"{x} divide by {y} is {x.DivideBy(y)}");

            string s = "hello";
            s.NoOfChars();
        }
    }

    static class ExtCls
    {
        public static int Square(this int a)
        {
            return a * a;
        }
        public static int DivideBy(this int a,int b)
        {
            return a / b;
        }
        public static int NoOfChars(this string s)
        {
            return s.Length;
        }
    }
}
