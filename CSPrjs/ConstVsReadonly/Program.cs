namespace ConstVsReadonly
{
    internal class Program
    {

        static void Main(string[] args)
        {
            
        }
    }

    class Demo
    {
        const int c = 100;
        readonly int r = 100;
        public Demo()
        {
            //c = 200;//invalid
            r = 200; //valid
        }
        public void SetValue()
        {
            //r = 500; //invalid
        }
    }
}
