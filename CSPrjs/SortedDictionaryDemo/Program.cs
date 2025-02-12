namespace SortedDictionaryDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<int,string> keyValuePairs = new SortedDictionary<int,string>();

            keyValuePairs.Add(5, "AAA");
            keyValuePairs.Add(1, "BBB");
            keyValuePairs.Add(4, "CCC");

            foreach (int k in keyValuePairs.Keys)
            {
                Console.WriteLine(k + ":" + keyValuePairs[k]);
            }
        }
    }
}
