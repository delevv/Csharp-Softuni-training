using System;
using System.Linq;
namespace PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] houses = Console.ReadLine().Split("@").Select(int.Parse).ToArray();

            string command;
            int index = 0;
            int lastIndex = 0;
            while ((command = Console.ReadLine()) != "Merry Xmas!")
            {
                string[] jump = command.Split();

                int lenght = int.Parse(jump[1]);

                if (index + lenght < houses.Length)
                {
                    index += lenght;
                    if (houses[index] > 0)
                    {
                        houses[index] -= 2;
                    }
                    else
                    {
                        Console.WriteLine($"House {index} will have a Merry Christmas.");
                    }
                }
                else
                {
                    index = lenght - (houses.Length - 1 - index) - 1;
                    while (index >= houses.Length)
                    {
                        index -= houses.Length;
                    }

                    if (houses[index] > 0)
                    {
                        houses[index] -= 2;
                    }
                    else
                    {
                        Console.WriteLine($"House {index} will have a Merry Christmas.");
                    }
                }
                lastIndex = index;
            }
            Console.WriteLine($"Santa's last position was {lastIndex}.");

            bool isHeFinished = true;
            int countOfHouses = 0;
            foreach (var house in houses)
            {
                if (house > 0)
                {
                    isHeFinished = false;
                    countOfHouses++;
                }
            }

            if (isHeFinished)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Santa has failed {countOfHouses} houses.");
            }
        }
    }
}
