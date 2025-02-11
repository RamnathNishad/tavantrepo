
enum MenuChoice
{
    ADD=1,
    SUBTRACT,
    MULTIPLY,
    DIVIDE,
    EXIT = 0
};
public class Program
{
    public static void Main(string[] args)
    {

        int n1, n2, result, choice;
        do
        {
            Console.WriteLine("1.Add");
            Console.WriteLine("2.Subtract");
            Console.WriteLine("3.Multiply");
            Console.WriteLine("4.Divide");
            Console.WriteLine("0.Exit");
            Console.Write("Enter choice:");
            choice = int.Parse(Console.ReadLine());
            Console.Write("Enter n1:");

            n1 = int.Parse(Console.ReadLine());
            Console.Write("Enter n2:");
            n2 = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case (int)MenuChoice.ADD:
                    result = n1 + n2;
                    Console.WriteLine("Sum:" + result);
                    break;
                case (int)MenuChoice.SUBTRACT:
                    result = n1 - n2;
                    Console.WriteLine("Difference:" + result);
                    break;
                case (int)MenuChoice.MULTIPLY:
                    result = n1 * n2;
                    Console.WriteLine("Multiply:" + result);
                    break;
                case (int)MenuChoice.DIVIDE:
                    result = n1 / n2;
                    Console.WriteLine("Division:" + result);
                    break;
                case (int)MenuChoice.EXIT:
                    Console.WriteLine("Exited...");
                    break;
                default:
                    Console.WriteLine("invalid choice");
                    break;
            }
        } while (choice != 0);

    }
}
//enum default starting value is 0
//every next member has the consecutive value from the previous
//used for integers only not for string or decimals



