namespace SampleDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int x ;
            int y;

            Console.WriteLine("Enter n1:");
            x = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter n2:");
            y = int.Parse(Console.ReadLine());

            Console.WriteLine("Sum:" + (x + y));
        }
    }
}
