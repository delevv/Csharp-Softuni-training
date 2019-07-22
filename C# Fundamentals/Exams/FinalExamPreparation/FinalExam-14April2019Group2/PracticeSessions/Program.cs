using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeSessions
{
    class Program
    {
        static void Main(string[] args)
        {
            var roadsAndRacers = new Dictionary<string, List<string>>();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split("->");

                string action = commandArgs[0];
                string road = commandArgs[1];

                if (action == "Add")
                {
                    string racer = commandArgs[2];

                    if (!roadsAndRacers.ContainsKey(road))
                    {
                        roadsAndRacers[road] = new List<string>();
                    }
                    roadsAndRacers[road].Add(racer);
                }
                else if (action == "Move")
                {
                    string racer = commandArgs[2];
                    string nextRoad = commandArgs[3];

                    if (roadsAndRacers[road].Contains(racer))
                    {
                        roadsAndRacers[road].Remove(racer);
                        roadsAndRacers[nextRoad].Add(racer);
                    }
                }
                else if (action == "Close")
                {
                    if (roadsAndRacers.ContainsKey(road))
                    {
                        roadsAndRacers.Remove(road);
                    }
                }
            }
            roadsAndRacers = roadsAndRacers
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine("Practice sessions: ");

            foreach (var road in roadsAndRacers)
            {
                Console.WriteLine(road.Key);

                foreach (var racer in road.Value)
                {
                    Console.WriteLine($"++{racer}");
                }
            }
        }
    }
}
