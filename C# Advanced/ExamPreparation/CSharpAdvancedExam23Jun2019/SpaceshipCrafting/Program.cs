using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceshipCrafting
{
    class Program
    {
        static void Main(string[] args)
        {
            var chemicalLiquids = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var physicalItems = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            var advancedMaterials = new Dictionary<string, int>();
            advancedMaterials.Add("Glass", 0);
            advancedMaterials.Add("Aluminium", 0);
            advancedMaterials.Add("Lithium", 0);
            advancedMaterials.Add("Carbon fiber", 0);

            while(chemicalLiquids.Any()&& physicalItems.Any())
            {
                var chemical = chemicalLiquids.Dequeue();
                var item = physicalItems.Pop();

                var sum = chemical + item;

                if (sum == 25)
                {
                    advancedMaterials["Glass"]++;
                }
                else if (sum == 50)
                {
                    advancedMaterials["Aluminium"]++;
                }
                else if (sum == 75)
                {
                    advancedMaterials["Lithium"]++;
                }
                else if (sum == 100)
                {
                    advancedMaterials["Carbon fiber"]++;
                }
                else
                {
                    physicalItems.Push(item + 3);
                }
            }

            bool isEnoughMaterials = true;

            foreach (var material in advancedMaterials)
            {
                if (material.Value == 0)
                {
                    isEnoughMaterials = false;
                }
            }

            if (isEnoughMaterials)
            {
                Console.WriteLine($"Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (chemicalLiquids.Any())
            {
                Console.WriteLine($"Liquids left: {string.Join(", ",chemicalLiquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (physicalItems.Any())
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", physicalItems)}");
            }
            else
            {
                Console.WriteLine("Physical items left: none");
            }

            foreach (var material in advancedMaterials.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }
    }
}
