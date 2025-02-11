namespace StringConversions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //working with System.Convert method
            //it is used to convert from one type any other type
            double d1 =Convert.ToDouble("12.5");
            Console.WriteLine(d1);

            //parse method
            //it is used always from string type to other type
            string s1 = null;// "10.5";

            //double d2=double.Parse(s1);
            //double d2=Convert.ToDouble(s1);
            double d2;
            double.TryParse(s1, out d2);

            Console.WriteLine(d2);



        }
    }
}
