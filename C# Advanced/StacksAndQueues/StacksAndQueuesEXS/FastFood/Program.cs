using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            var foodQuantity = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queue = new Queue<int>(orders);
            var maxOrder = queue.Max();

            while (queue.Count > 0)
            {
                var orderQuantity = queue.Peek();

                if (foodQuantity - orderQuantity >= 0)
                {
                    foodQuantity -= queue.Dequeue();
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(maxOrder);

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ",queue)}");
            }
        }
    }
}
