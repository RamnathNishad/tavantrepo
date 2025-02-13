namespace PropertiesDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Customer customer = new Customer();
            //customer.CustId = 1001;
            //customer.CustName = "Ravi";
            //customer.City = "mysore";

            //Object initializer syntax
            Customer customer = new Customer 
            { 
                CustId=1001,
                CustName="John",
                City="Mysore"
            };

            Console.WriteLine(customer.CustId);
            Console.WriteLine(customer.City);

            //Collection initializer syntax
            List<Customer> list = new List<Customer>
            {
                new Customer{ CustId=1,CustName="Ram",City="Delhi"},
                new Customer{ CustId=2,CustName="Ravi",City="Delhi"},
                new Customer{ CustId=3,CustName="Suresh",City="Delhi"}
            };

        }
    }
    class Customer
    {
        public Customer(string City)
        {
            this.City = City;
        }
        public Customer() { }
        public int CustId { get; set; }
        public string CustName { get; set; }
        public string City {  get;  set; }
    }
}
