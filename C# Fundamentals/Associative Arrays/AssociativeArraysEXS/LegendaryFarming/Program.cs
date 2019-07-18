using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            var materials = new Dictionary<string, int>()
            {
                ["shards"] = 0,
                ["fragments"] = 0,
                ["motes"] = 0
            };
            var junk = new SortedDictionary<string, int>();
            string bestKey = "";

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                bool isCollected = false;
                for (int i = 0; i < input.Length - 1; i += 2)
                {
                    int value = int.Parse(input[i]);
                    string type = input[i + 1].ToLower();

                    if (type == "shards" || type == "fragments" || type == "motes")
                    {
                        materials[type] += value;
                        if (materials[type] >= 250)
                        {
                            isCollected = true;
                            bestKey = type;
                            break;
                        }
                    }
                    else
                    {
                        if (!junk.ContainsKey(type))
                        {
                            junk[type] = 0;
                        }
                        junk[type] += value;
                    }
                }
                if (isCollected)
                {
                    materials[bestKey] -= 250;

                    if (bestKey == "shards") bestKey = "Shadowmourne";
                    else if (bestKey == "fragments") bestKey = "Valanyr";
                    else if (bestKey == "motes") bestKey = "Dragonwrath";

                    Console.WriteLine($"{bestKey} obtained!");
                    break;
                }
            }
            materials = materials.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var material in materials)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
            foreach (var item in junk)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
