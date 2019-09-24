using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            var countOfCars = int.Parse(Console.ReadLine());

            var queue = new Queue<string>();
            var command = "";
            var passedCarsCount = 0;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command != "green")
                {
                    queue.Enqueue(command);
                }
                else
                {
                    for (int i = 0; i < countOfCars; i++)
                    {
                        if (queue.Count > 0)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            passedCarsCount++;
                        }
                    }
                }
            }
            Console.WriteLine($"{passedCarsCount} cars passed the crossroads.");
        }
    }
}
