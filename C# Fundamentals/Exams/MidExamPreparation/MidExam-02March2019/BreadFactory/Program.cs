using System;
using System.Linq;

namespace BreadFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("|").ToArray();

            int coins = 100;
            int energy = 100;
            for (int i = 0; i < input.Length; i++)
            {
                string[] currentEvent = input[i].Split("-").ToArray();

                if (currentEvent[0] == "rest")
                {
                    int gainedEnergy = int.Parse(currentEvent[1]);

                    if (energy + gainedEnergy <= 100)
                    {
                        Console.WriteLine($"You gained {gainedEnergy} energy.");
                        energy += gainedEnergy;
                    }
                    else
                    {
                        gainedEnergy = 100 - energy;
                        Console.WriteLine($"You gained {gainedEnergy} energy.");
                    }
                    Console.WriteLine($"Current energy: {energy}.");
                }
                else if (currentEvent[0] == "order")
                {
                    if (energy - 30 >= 0)
                    {
                        int earnedCoins = int.Parse(currentEvent[1]);
                        energy -= 30;
                        coins += earnedCoins;
                        Console.WriteLine($"You earned {earnedCoins} coins.");
                    }
                    else
                    {
                        Console.WriteLine("You had to rest!");
                        if (energy + 50 <= 100)
                        {
                            energy += 50;
                        }
                        else
                        {
                            energy = 100;
                        }
                    }
                }
                else
                {
                    string ingredient = currentEvent[0];
                    int spendCoins = int.Parse(currentEvent[1]);

                    if (coins-spendCoins> 0)
                    {
                        Console.WriteLine($"You bought {ingredient}.");
                        coins -= spendCoins;
                    }
                    else
                    {
                        coins -= spendCoins;
                        Console.WriteLine($"Closed! Cannot afford {ingredient}.");
                        break;
                    }
                }
            }
            if (coins > 0)
            {
                Console.WriteLine("Day completed!");
                Console.WriteLine($"Coins: {coins}");
                Console.WriteLine($"Energy: {energy}");
            }
        }
    }
}
