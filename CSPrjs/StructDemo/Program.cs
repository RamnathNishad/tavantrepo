struct Address
{
    string city;
    string country;
    public string pin;
    public void Store(string city,string country,string pin)
    {
        this.city = city;
        this.country = country;
        this.pin = pin;
    }
    public void Display()
    {
        Console.WriteLine($"City:{city}\nCountry:{country}\nPin:{pin}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Address address = new Address();
        address.Store("Bangalore", "India", "560054");
        address.Display();

        Address adr2 = address;
        adr2.pin = "560047";
        address.Display();
        adr2.Display();

    }
}

//1.struct is a value-type variable
//2.struct may have constructor(parameterized only) but 
//no destructor
//3.can have member methods
//4.field initialization is not allowed 
