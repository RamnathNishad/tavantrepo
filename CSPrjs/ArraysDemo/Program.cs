using System.Collections;

public class Program
{
    public static void Main(string[] args)
    {
        //SingleDimensionArray();

        //RectangularArrayDemo(); 

        //JaggedArrayDemo();

        string[] names = { "Ravi", "Rahul", "Rohit", "Ramesh" };

        Console.WriteLine("Traversing using for-index");
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine(names[i]);
        }

        Console.WriteLine("\nTraversing using foreach loop");
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("\nTraversing using IEnumerator interface");
        IEnumerator ien= names.GetEnumerator();

        while (ien.MoveNext())
        {
            string name = ien.Current.ToString();
            Console.WriteLine(name);
        }

    }

    private static void JaggedArrayDemo()
    {
        //jagged array
        //int[][] jaggedArray=new int[3][];
        //jaggedArray[0] = new int[3];
        //jaggedArray[0][0] = 10;
        //jaggedArray[0][1] = 20;
        //jaggedArray[0][2] = 30;

        //jaggedArray[1] = new int[4];
        //jaggedArray[1][0] = 40;
        //jaggedArray[1][1] = 50;
        //jaggedArray[1][2] = 60;
        //jaggedArray[1][3] = 70;

        //jaggedArray[2] = new int[2];
        //jaggedArray[2][0] = 80;
        //jaggedArray[2][1] = 90;

        //OR
        int[][] jaggedArray = new int[3][] {
                                            new int[]{10,20,30,40 } ,
                                            new int[]{ 50,60,70},
                                            new int[]{80,90 }
                                        };

        for (int i = 0; i < jaggedArray.GetLength(0); i++)
        {
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                Console.Write(jaggedArray[i][j] + "\t");
            }
            Console.WriteLine("");
        }
    }

    private static void RectangularArrayDemo()
    {
        //multi-dimesnional rectangular array
        //int[,] numbers = new int[3,3];
        //numbers[0,0] = 1; numbers[1,0] = 2; numbers[2,0] = 3;

        //OR
        //int[,] numbers = new int[,] { 
        //                                { 10,20,30},
        //                                { 40,50,60 },
        //                                { 70,80,90 } 
        //                            };

        //OR
        int[,] numbers = { { 10, 20, 30, 35 }, { 40, 50, 60, 65 }, { 70, 80, 90, 95 } };

        for (int i = 0; i < numbers.GetLength(0); i++)
        {
            for (int j = 0; j < numbers.GetLength(1); j++)
            {
                Console.Write(numbers[i, j] + "\t");
            }
            Console.WriteLine("");
        }
    }

    private static void SingleDimensionArray()
    {
        //syntax=>
        //data-type[] array_name=new data-type[size];

        //int[] numbers = new int[5];
        //numbers[0] = 10;numbers[1] = 20;
        //OR

        //int[] numbers = new int[] { 10,20,30,40,50};
        //OR
        int[] numbers = { 10, 20, 30 };

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}
