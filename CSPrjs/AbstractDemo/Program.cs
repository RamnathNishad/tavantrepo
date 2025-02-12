namespace AbstractDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("static binding"); 
            Circle c=new Circle();
            c.Area();
            Square square=new Square();
            square.Area();


            Console.WriteLine("\ndynamic binding");
            Shape sh;

            sh = new Circle();
            sh.Area();

            sh = new Square();
            sh.Area();

        }
    }

    abstract class Shape
    {
        //area
        public abstract void Area();
        //perimeter
    }
    class Circle : Shape
    {
        public override void Area()
        {
            Console.WriteLine("Area of Circle");
        }
    }
    class Square :Shape
    {
        public override void Area()
        {
            Console.WriteLine("Area of Square");
        }
    }
}
