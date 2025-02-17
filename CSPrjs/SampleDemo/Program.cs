using MyLibrary;


namespace SampleDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Customer customer = new Customer();
            customer.Name = "Test";
            

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
class Child : Customer
{
    public void Show()
    {
        pro_intrnl = 100;
        pro_var = 100;
    }
}