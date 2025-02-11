namespace DateTimeConversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine(dateTime);
            Console.Write("Enter dob(dd-MON-yyyy):");
            string s1 = Console.ReadLine();
            DateTime dt2 = DateTime.ParseExact(s1, "dd-MMM-yyyy", null);
            
            Console.WriteLine(dt2.ToString("dd-MMM-yyyy"));

            DateTime dt3=dt2.AddDays(2);
            Console.WriteLine(dt3);
        }
    }
}
