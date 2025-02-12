namespace InterfaceDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAccount account = null;

            account = new SavingsAccount(5000);
            Console.WriteLine(account.Deposit(1000)?"Deposited":"Failed deposit");

            Console.WriteLine(account.WithDraw(4000) ? "Withdrawn" : "Failed withdrawl");

            account = new CurrentAccount(0);
            Console.WriteLine(account.Deposit(1000) ? "Deposited" : "Failed deposit");

            Console.WriteLine(account.WithDraw(4000) ? "Withdrawn" : "Failed withdrawl");

            //GC.Collect();//forced GC for all generations

            //GC.SuppressFinalize(account);
        }
    }

    interface IAccount
    {
        bool WithDraw(int amount);
        bool Deposit(int amount);
    }
    class SavingsAccount : IAccount
    {
        int balance;
        public SavingsAccount(int balance)
        {
            this.balance = balance;
        }
        public bool Deposit(int amount)
        {
            if(amount<=0)
            {
                return false;
            }
            balance += amount;
            return true;
        }

        public bool WithDraw(int amount)
        {
            if(amount>balance)
            {
                return false;
            }
            balance -= amount;
            return true;
        }
    }

    class CurrentAccount : IAccount
    {
        int balance;
        public CurrentAccount(int balance)
        {
            this.balance = balance;
        }
        public bool Deposit(int amount)
        {
            if (amount <= 0)
            {
                return false;
            }
            balance += amount;
            return true;
        }

        public bool WithDraw(int amount)
        {
            if (amount > balance)
            {
                return false;
            }
            balance -= amount;
            return true;
        }
    }
}
