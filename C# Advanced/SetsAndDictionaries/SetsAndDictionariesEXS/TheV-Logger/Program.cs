using System;
using System.Collections.Generic;
using System.Linq;

namespace TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var Vloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            var command = "";

            while ((command = Console.ReadLine()) != "Statistics")
            {
                var info = command.Split();

                var vloggerName = info[0];
                var action = info[1];

                if (action == "joined")
                {
                    if (!Vloggers.ContainsKey(vloggerName))
                    {
                        Vloggers[vloggerName] = new Dictionary<string, HashSet<string>>();

                        Vloggers[vloggerName]["followers"] = new HashSet<string>();
                        Vloggers[vloggerName]["follow"] = new HashSet<string>();
                    }
                }
                else if (action == "followed")
                {
                    var mainVlogger = info[2];

                    if (vloggerName != mainVlogger && Vloggers.ContainsKey(mainVlogger) && Vloggers.ContainsKey(vloggerName))
                    {
                        Vloggers[mainVlogger]["followers"].Add(vloggerName);
                        Vloggers[vloggerName]["follow"].Add(mainVlogger);
                    }
                }
            }
            Console.WriteLine($"The V-Logger has a total of {Vloggers.Count} vloggers in its logs.");

            var counter = 1;

            foreach (var vlogger in Vloggers.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["follow"].Count))
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["follow"].Count} following");

                if (counter == 1)
                {
                    foreach (var follower in vlogger.Value["followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                counter++;
            }
        }
    }
}
