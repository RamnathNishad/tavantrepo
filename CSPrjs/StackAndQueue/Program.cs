namespace StackAndQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);


            Console.WriteLine(stack.Peek());

            int length=stack.Count;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(stack.Pop());
            }

            Console.WriteLine("");
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Console.WriteLine(queue.Peek());
            length = queue.Count;
            for (int i = 0;i < length;i++)
            {
                Console.WriteLine(queue.Dequeue());
            }

        }
    }
}
