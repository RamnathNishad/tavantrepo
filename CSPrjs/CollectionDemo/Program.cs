using System.Collections;

namespace CollectionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrLst = new ArrayList();
            arrLst.Add(10);
            arrLst.Add(20);
            arrLst.Add("AAA");
            arrLst.Add(40);
            arrLst.Add(50);

            foreach (object v in arrLst)
            {
                if(v is int)
                {
                    int x = (int)v;
                    Console.WriteLine(x);
                }
                else if (v is string)
                {
                    string s = v.ToString();
                    Console.WriteLine(s);
                }
              
                //Console.WriteLine(v);
            }
        }
    }
}
