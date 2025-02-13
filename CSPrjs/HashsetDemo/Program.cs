namespace HashsetDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set1 = new HashSet<string>();

            set1.Add("Ravi");
            set1.Add("Rahul");
            set1.Add("Rohit");


            HashSet<string> set2 = new HashSet<string>();

            set2.Add("Suresh");
            set2.Add("Ravi");
            set2.Add("Tom");

            //set1.UnionWith(set2);
            //set1.IntersectWith(set2);
            set1.ExceptWith(set2);

            foreach (string s in set1)
            {
                Console.WriteLine(s);
            }
        }
    }
}
