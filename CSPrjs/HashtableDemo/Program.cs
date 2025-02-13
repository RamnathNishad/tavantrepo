using System.Collections;

namespace HashtableDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            ht.Add(101, "Ravi");
            ht.Add(102, "Rahul");
            ht.Add(103, "Rohit");

            Console.WriteLine(ht[101].ToString());

            foreach (object k in ht.Keys)
            {
                Console.WriteLine(ht[k]);
            }
        }
    }
}
