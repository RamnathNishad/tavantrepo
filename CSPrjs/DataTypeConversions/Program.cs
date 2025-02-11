public class Program
{
    public static void Main(string[] args)
    {
        //1.value to value
        int x = 100;
        long l = 2147483648; //implicit
        Console.WriteLine(int.MaxValue);

        int y = (int)l; //explicit, chance of data loss
        Console.WriteLine($"long:{l}\tint:{y}");

        //2. value to reference 
        int a = 100;
        object o = a; //boxing , implicit

        //3.reference to value
        int b = (int)o; //unboxing,explicit

        //4.reference to reference
        Parent p=new Parent();
        Child ch = (Child)p;

        Parent p2 = new Child(); //implicit

    }
}
class Parent
{
    //todo
}
class Child : Parent
{
    //todo
}
