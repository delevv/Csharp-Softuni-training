using System;
using System.Collections.Generic;
using System.Linq;

namespace FeedTheAnimals
{
    class Program
    {
        static void Main(string[] args)
        {
            var animals = new Dictionary<string, int>();
            var areas = new Dictionary<string, int>();

            string command;

            while((command=Console.ReadLine())!="Last Info")
            {
                string[] commandArgs = command.Split(":");

                string action = commandArgs[0];
                string name = commandArgs[1];
                int food = int.Parse(commandArgs[2]);
                string area = commandArgs[3];

                if (action == "Add")
                {
                    if (!animals.ContainsKey(name))
                    {
                        animals[name] = food;

                        if (!areas.ContainsKey(area))
                        {
                            areas[area] = 1;
                        }
                        else
                        {
                            areas[area]++;
                        }
                    }
                    else
                    {
                        animals[name]+= food;
                    }
                }
                else if (action == "Feed")
                {
                    if (animals.ContainsKey(name))
                    {
                        animals[name] -= food;

                        if (animals[name] <= 0)
                        {
                            Console.WriteLine($"{name} was successfully fed");
                            animals.Remove(name);
                            areas[area]--;
                        }
                    }
                }
            }
            animals = animals
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine("Animals: ");
            
                foreach (var animal in animals)
                {
                    Console.WriteLine($"{animal.Key} -> {animal.Value}g");
                }

            areas = areas
                .OrderByDescending(x => x.Value)
                .Where(x=>x.Value>0)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine("Areas with hungry animals: ");

            foreach (var area in areas)
            {
                Console.WriteLine($"{area.Key} : {area.Value}");
            }
        }
    }
}
