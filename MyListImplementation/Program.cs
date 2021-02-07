using System;

namespace MyListImplementation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // string, double, int
            List list = new List();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            Console.WriteLine("List: ");
            do
            {
                Console.Write(list.Current);
                Console.Write(" ");
            } while (list.MoveNext());

            Console.WriteLine();
            Console.WriteLine("Queue: ");

            Queue queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            while (queue.Count > 0)
            {
                Console.Write(queue.Dequeue());
                Console.Write(" ");
            }

            while (queue.Count > 0)
            {
                Console.Write(queue.Dequeue());
                Console.Write(" ");
            }

            Console.WriteLine();
            Console.WriteLine("Stack: ");

            Stack stack = new Stack();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            while (stack.Count > 0)
            {
                Console.Write(stack.Pull());
                Console.Write(" ");
            }
        }
    }
}
