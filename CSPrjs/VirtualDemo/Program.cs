namespace VirtualDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int marks = 55;
            College1 c1 = new College1();
            Console.WriteLine("College1 result:"+ c1.GetResult(marks));

            College2 c2 = new College2();
            Console.WriteLine("College2 result:" + c2.GetResult(marks));

        }
    }

    class University
    {
        public virtual string GetResult(int marks)
        {
            if(marks>=50)
            {
                return "Pass";
            }
            else
            {
                return "Failed";
            }
        }
    }

    class College1 : University
    {
    }
    class College2: University
    {
        public override string GetResult(int marks)
        {
            if (marks >= 60)
            {
                return "Pass";
            }
            else
            {
                return "Failed";
            }
        }
    }
}
