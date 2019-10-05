using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var countOfClothes = int.Parse(Console.ReadLine());

            var clothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < countOfClothes; i++)
            {
                var currentClothes = Console.ReadLine().Split(" -> ");
                var colorOfClothes = currentClothes[0];
                var clothesType = currentClothes[1].Split(",");

                if (!clothes.ContainsKey(colorOfClothes))
                {
                    clothes[colorOfClothes] = new Dictionary<string, int>();
                }

                foreach (var type in clothesType)
                {
                    if (!clothes[colorOfClothes].ContainsKey(type))
                    {
                        clothes[colorOfClothes][type] = 1;
                    }
                    else
                    {
                        clothes[colorOfClothes][type]++;
                    }
                }
            }
            var targetClothes = Console.ReadLine().Split(" ");
            var targetColor = targetClothes[0];
            var targetType = targetClothes[1];

            foreach (var color in clothes)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var type in color.Value)
                {
                    if(color.Key==targetColor && type.Key == targetType)
                    {
                        Console.WriteLine($"* {type.Key} - {type.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {type.Key} - {type.Value}");
                    }
                }
            }
        }
    }
}
