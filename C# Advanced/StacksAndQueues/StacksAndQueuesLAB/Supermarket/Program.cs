using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = "";
            var queue = new Queue<string>();

            while ((command = Console.ReadLine()) != "End")
            {
                if (command != "Paid")
                {
                    queue.Enqueue(command);
                }
                else
                {
                    while (queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
