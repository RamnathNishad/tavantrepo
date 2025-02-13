namespace CustomExceptionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
         try
            {
                Account account = new Account(5000);
                account.Deposit(-1000);
                Console.WriteLine("Amount deposited:" + account.Balance);
                account.WithDraw(2000);
                Console.WriteLine("Amount withdrawn:" + account.Balance);
                account.WithDraw(7000);
                Console.WriteLine("Amount withdrawn:" + account.Balance);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine(ex.Message);                               
            }
            catch (InvalidDepositFigureException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    class Account
    {
        public int Balance { get; set; }
        public Account(int balance)
        {
            this.Balance = balance;
        }
        public void WithDraw(int amount)
        {
            if(amount>Balance)
            {
                throw new InsufficientFundsException("insufficient funds to withdraw!!!");
            }
            this.Balance -= amount;
        }
        public void Deposit(int amount)
        {
            if(amount<=0)
            {
                throw new InvalidDepositFigureException("Amount must be >0");
            }
            this.Balance += amount;
        }
    }
}
class InsufficientFundsException : ApplicationException
{
    public InsufficientFundsException(string errMsg)
        :base(errMsg)
    {
        
    }
    public InsufficientFundsException(string errMsg,Exception inner)
        :base(errMsg)
    {

    }
}
class InvalidDepositFigureException : Exception
{
    public InvalidDepositFigureException(string errMsg)
        : base(errMsg)
    {

    }
}