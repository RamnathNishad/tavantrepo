namespace LabSeatBooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] seats = new int[25, 25];
            Console.Write("Enter starting seat number:");
            int seatNo=int.Parse(Console.ReadLine());
            Console.Write("Number of seats to book:");
            int noOfSeats=int.Parse(Console.ReadLine());


        }
        static bool CheckSeatAvailability(int seatNo, int noOfSeats, int[,] seats)
        {
            bool status = true;

            int row = seats / 25;
            int col = seats % 25;
            for (int j = col; j < noOfSeats; j++)
            {
                if (seats[row, j] == 1)
                {
                    status = false;
                    break;
                }
                if(j>25)
                {
                    row++;
                }
            }
            return status;
        }
    }
}
