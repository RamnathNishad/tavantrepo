namespace DictinaryDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int,string> books = new Dictionary<int,string>(); ;
            books.Add(101, "C# for Beginners");
            books.Add(102, "Learning SQL Server");
            books.Add(103, "ASP.Net for Dummies");

            int bid = 104;
            if (books.ContainsKey(bid))
            {

                Console.WriteLine($"Bookid:{bid}\t{books[bid]}");
            }
            else
            {
                Console.WriteLine("Book id not present");
            }

            //traversing using keys
            foreach (int k in books.Keys)
            {
                //Console.WriteLine($"Book id:{k}\tBook name:{books[k]}");
            }

            //traverse using values
            foreach(string v in books.Values)
            {
                //Console.WriteLine(v);
            }
            
            //travers using KeyValue pair
            foreach(KeyValuePair<int,string> kv in books)
            {
                int key = kv.Key;
                string value = kv.Value;
                Console.WriteLine($"Book id:{key}\tBook name:{value}");
            }

           IEnumerator<int> ien_k= books.Keys.GetEnumerator();
            while (ien_k.MoveNext())
            {
                int k = ien_k.Current;
                string v=books[k];
                Console.WriteLine($"bid:{k}\tbname:{v}");
            }
        }
    }
}
