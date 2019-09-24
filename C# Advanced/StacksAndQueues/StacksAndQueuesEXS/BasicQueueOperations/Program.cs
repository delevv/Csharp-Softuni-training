using System;
using System.Collections.Generic;
using System.Linq;

namespace queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var info = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var elementsCount = info[0];
            var elementsToDequeue = info[1];
            var specialNumber = info[2];

            var queue = new Queue<int>();

            for (int i = 0; i < elementsCount; i++)
            {
                queue.Enqueue(elements[i]);
            }
            for (int i = 0; i < elementsToDequeue; i++)
            {
                if (queue.Count != 0)
                {
                    queue.Dequeue();
                }
            }
            if (queue.Contains(specialNumber))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count > 0)
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
