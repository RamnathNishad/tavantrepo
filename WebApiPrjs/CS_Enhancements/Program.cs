
using CS_Enhancements;

Demo d=new Demo();
int  b = 200;
int c=d.Method1(out int a, ref b);
c++;

int? x = null;

//d.Method1(b:10, out a:20);
//d.Method1(10);


dynamic x = 100;

x = "hello";
Console.WriteLine(x.Length);

string str = "Hello";
//if(s!=null)
//Console.WriteLine(s?.Length);

Console.WriteLine("name of variable is :" + nameof(str));

var obj2 = (10,20);
Console.WriteLine(obj2.Item1);
Console.WriteLine(obj2.Item2);

(int a,string b)obj = (100,"Hello");

Console.WriteLine(obj.a);
Console.WriteLine(obj.b);

try
{
    //
}
catch(DivideByZeroException ex) when (ex.InnerException != null)
{

}