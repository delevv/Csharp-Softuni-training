using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            var pumps = int.Parse(Console.ReadLine());
            var queue = new Queue<int[]>();

            for (var i = 0; i < pumps; i++)
            {
                queue.Enqueue(Console.ReadLine().Split().Select(int.Parse).ToArray());
            }
            bool isItTheRight = false;

            for (var i = 0; i < pumps; i++)
            {
                var fuel = 0;
                foreach (var item in queue)
                {
                    fuel += item[0] - item[1];
                    if (fuel < 0)
                    {
                        isItTheRight = false;
                        break;
                    }
                    else
                    {
                        isItTheRight = true;
                    }
                }
                if (isItTheRight)
                {
                    Console.WriteLine(i);
                    return;
                }
                queue.Enqueue(queue.Dequeue());
            }
        }
    }
}
