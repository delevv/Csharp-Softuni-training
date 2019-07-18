using System;
using System.Collections.Generic;
using System.Linq;

namespace SnowWhite
{
    class Program
    {
        static void Main(string[] args)
        {
            var dwarfs = new Dictionary<string, int>();

            string command;

            while ((command=Console.ReadLine())!="Once upon a time")
            {
                string[] dwarfInfo = command.Split();

                string id = dwarfInfo[0] + dwarfInfo[1] + dwarfInfo[2];

                int physics = int.Parse(dwarfInfo[4]);

                if (!dwarfs.ContainsKey(id))
                {
                    dwarfs[id] = physics;
                }
                else
                {
                    if (dwarfs[id] < physics)
                    {
                        dwarfs[id] = physics;
                    }
                }
            }
            dwarfs = dwarfs.OrderByDescending(x => x.Value)
                .ThenByDescending(x => dwarfs.Where(y => y.Key.Split("<:>")[1] == x.Key.Split("<:>")[1]).Count())
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var dwarf in dwarfs)
            {
                Console.WriteLine($"({dwarf.Key.Split("<:>")[1]}) {dwarf.Key.Split("<:>")[0]} <-> {dwarf.Value}");
            }
        }
    }
}
