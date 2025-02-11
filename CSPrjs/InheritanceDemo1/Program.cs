namespace InheritanceDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TWO-WHEELERES Features");
            TwoWheeler discover = new TwoWheeler();
            discover.Brake();
            discover.Horn();
            discover.Stand();

            Console.WriteLine("\nFOUR-WHEELERS features");
            FourWheeler maruti = new FourWheeler();
            maruti.Brake();
            maruti.Horn();
            maruti.Ac();
            maruti.Music();


        }
    }

    class Vehicle
    {
        public void Brake()
        {
            Console.WriteLine("Brake");
        }
        public void Horn()
        {
            Console.WriteLine("Horn");
        }
    }
    class TwoWheeler : Vehicle
    {
        public void Stand()
        {
            Console.WriteLine("Stand");
        }
    }
    class FourWheeler : Vehicle
    {
        public void Ac()
        {
            Console.WriteLine("AC");
        }
        public void Music()
        {
            Console.WriteLine("Music");
        }
    }
}
