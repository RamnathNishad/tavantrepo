namespace PredefinedException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int n1, n2, result;
                Console.Write("Enter n1:");
                n1 = int.Parse(Console.ReadLine());
                Console.Write("Enter n2:");
                n2 = int.Parse(Console.ReadLine());

                result = n1 / n2;
                Console.WriteLine("result:" + result);

            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Have a good day!!!");
            }
        }
    }
}
