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
                List<int> batch = command.Split("#").Select(int.Parse).ToList();

                int currentTotal = batch.Sum();
                int currentCount = batch.Count;

                if (currentTotal > bestTotal)
                {
                    bestTotal = currentTotal;
                    bestCount = currentCount;
                    bestBatch = batch.ToList();
                }
                else if (currentTotal == bestTotal)
                {
                    if (batch.Average() > bestBatch.Average())
                    {
                        bestTotal = currentTotal;
                        bestCount = currentCount;
                        bestBatch = batch.ToList();
                    }
                }
                if(currentTotal==bestTotal && batch.Average() == bestBatch.Average())
                {
                    if (batch.Count < bestBatch.Count)
                    {
                        bestTotal = currentTotal;
                        bestCount = currentCount;
                        bestBatch = batch.ToList();
                    }
                }
            }
            Console.WriteLine($"Best Batch quality: {bestTotal}");
            Console.WriteLine(string.Join(" ",bestBatch));
        }
    }
}
