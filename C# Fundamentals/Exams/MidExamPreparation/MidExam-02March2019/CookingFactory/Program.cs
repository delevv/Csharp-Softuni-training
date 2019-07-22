using System;
using System.Collections.Generic;
using System.Linq;

namespace CookingFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> bestBatch = new List<int>();
            int bestTotal = int.MinValue;
            int bestCount = 0;
            string command;

            while ((command = Console.ReadLine()) != "Bake It!")
            {
                List<int> batches = command.Split("#").Select(int.Parse).ToList();

                int currentTotal = batches.Sum();
                int currentCount = batches.Count;

                if (currentTotal > bestTotal)
                {
                    bestTotal = currentTotal;
                    bestCount = currentCount;
                    bestBatch = batches.ToList();
                }
                else if (currentTotal == bestTotal)
                {
                    if (batches.Average() > bestBatch.Average())
                    {
                        bestTotal = currentTotal;
                        bestCount = currentCount;
                        bestBatch = batches.ToList();
                    }
                }
                if(currentTotal==bestTotal && batches.Average() == bestBatch.Average())
                {
                    if (batches.Count < bestBatch.Count)
                    {
                        bestTotal = currentTotal;
                        bestCount = currentCount;
                        bestBatch = batches.ToList();
                    }
                }
            }
            Console.WriteLine($"Best Batch quality: {bestTotal}");
            Console.WriteLine(string.Join(" ",bestBatch));
        }
    }
}
