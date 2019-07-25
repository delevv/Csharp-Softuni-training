using System;
using System.Collections.Generic;
using System.Linq;

namespace Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            var bands = new Dictionary<string, List<string>>();
            var bandsAndTime = new Dictionary<string, int>();

            string command;

            while((command=Console.ReadLine())!="start of concert")
            {
                string[] commandArgs = command.Split("; ");

                string action = commandArgs[0];
                string bandName = commandArgs[1];

                if (action == "Add")
                {
                    if (!bands.ContainsKey(bandName))
                    {
                        bands[bandName] = new List<string>();
                    }
                    string[] members = commandArgs[2].Split(", ");

                    foreach (var member in members)
                    {
                        if (!bands[bandName].Contains(member))
                        {
                            bands[bandName].Add(member);
                        }
                    }
                }
                else if (action == "Play")
                {
                    int time = int.Parse(commandArgs[2]);
                    if (!bandsAndTime.ContainsKey(bandName))
                    {
                        bandsAndTime[bandName] = 0;
                    }
                    bandsAndTime[bandName] += time;
                }
            }
            Console.WriteLine($"Total time: {bandsAndTime.Values.Sum()}");

            bandsAndTime = bandsAndTime
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var band in bandsAndTime)
            {
                Console.WriteLine($"{band.Key} -> {band.Value}");
            }

            string selectedBand = Console.ReadLine();

            Console.WriteLine(selectedBand);

            foreach (var member in bands[selectedBand])
            {
                Console.WriteLine($"=> {member}");
            }
        }
    }
}
