namespace AggregationAndComposition
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Computer computer = new Computer();
            
            //Mouse mouse = new Mouse();
            //Monitor monitor = new Monitor();
            //computer.SetData(mouse, monitor); //aggretgation
           
            computer.SetData(); //composition
            computer.Display();

            computer = null;


        }
    }

    class Mouse
    {
        public void MouseFeatures()
        {
            Console.WriteLine("Mouse");
        }
    }
    class Monitor
    {
        public void MonitorFeatures()
        {
            Console.WriteLine("Monitor");
        }
    }
    class Computer
    {
        Mouse mouse;
        Monitor monitor;
        public void SetData(/*Mouse mouse,Monitor monitor*/)
        {
            mouse = new Mouse(); //composition
            monitor = new Monitor();
            //this.mouse = mouse; //aggregation
            //this.monitor = monitor;
        }
        public void Display()
        {
            this.monitor.MonitorFeatures();
            this.mouse.MouseFeatures();
        }
    }
}
