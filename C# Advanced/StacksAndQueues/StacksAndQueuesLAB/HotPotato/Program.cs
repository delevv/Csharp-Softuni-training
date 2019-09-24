using System;
using System.Collections.Generic;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var players = Console.ReadLine().Split();
            var toss = int.Parse(Console.ReadLine());

            var queue = new Queue<string>(players);

            while (queue.Count > 1)
            {
                for (int i = 0; i < toss-1; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
