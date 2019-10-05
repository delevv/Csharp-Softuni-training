using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var countOfElements = int.Parse(Console.ReadLine());

            var elements = new SortedSet<string>();

            for (int i = 0; i < countOfElements; i++)
            {
                var currentElements = Console.ReadLine().Split(" ");

                foreach (var element in currentElements)
                {
                    elements.Add(element);
                }
            }
            Console.WriteLine(string.Join(" ",elements));
        }
    }
}
