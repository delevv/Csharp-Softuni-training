using System;
using System.Linq;

namespace HelloFrance
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] itemsAndPrices = Console.ReadLine().Split("|").ToArray();
            double currentBudget = double.Parse(Console.ReadLine());
            double[] theirItems = new double[itemsAndPrices.Length];

            double budget = currentBudget;
            int itemsIndex = 0;

            for (int i = 0; i < itemsAndPrices.Length; i++)
            {
                string[] currentItem = itemsAndPrices[i].Split("->").ToArray();

                string type = currentItem[0];
                double price = double.Parse(currentItem[1]);
                if (type == "Clothes")
                {
                    if (price <= 50)
                    {
                        if (budget - price >= 0)
                        {
                            budget -= price;
                            theirItems[itemsIndex] = price + price * 0.4;
                            itemsIndex++;
                        }
                    }
                }
               else if (type == "Shoes")
                {
                    if (price <= 35)
                    {
                        if (budget - price >= 0)
                        {
                            budget -= price;
                            theirItems[itemsIndex] = price + price * 0.4;
                            itemsIndex++;
                        }
                    }
                }
                else if (type == "Accessories")
                {
                    if (price <=20.5)
                    {
                        if (budget - price >= 0)
                        {
                            budget -= price;
                            theirItems[itemsIndex] = price + price * 0.4;
                            itemsIndex++;
                        }
                    }
                }           
            }
            double sumOfItems = 0;
            for (int i = 0; i < theirItems.Length; i++)
            {
                if (theirItems[i] != 0)
                {
                    sumOfItems += theirItems[i];
                    Console.Write($"{theirItems[i]:f2} ");
                }
            }
            Console.WriteLine();
            double profit = sumOfItems+budget - currentBudget;

            budget += sumOfItems;
            Console.WriteLine($"Profit: {profit:f2}");

            if (budget >= 150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }

        }
    }
}
