using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            double firstRacer = 0;

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                if (numbers[i] != 0)
                {
                    firstRacer += numbers[i];
                }
                else
                {
                    firstRacer -= firstRacer * 0.2;
                }
            }
            double secondRacer = 0;

            for (int i = numbers.Count - 1; i > numbers.Count / 2; i--)
            {
                if (numbers[i] != 0)
                {
                    secondRacer += numbers[i];
                }
                else
                {
                    secondRacer -= secondRacer * 0.2;
                }
            }

            if (firstRacer < secondRacer)
            {
                Console.WriteLine($"The winner is left with total time: {firstRacer}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {secondRacer}");
            }
        }
    }
}
