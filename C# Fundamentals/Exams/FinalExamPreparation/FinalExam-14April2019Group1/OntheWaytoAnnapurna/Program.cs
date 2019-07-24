using System;
using System.Collections.Generic;
using System.Linq;

namespace OntheWaytoAnnapurna
{
    class Program
    {
        static void Main(string[] args)
        {
            var stores = new Dictionary<string, List<string>>();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split("->");

                string action = commandArgs[0];
                string store = commandArgs[1];

                if (action == "Add")
                {
                    string[] items = commandArgs[2].Split(",");

                    if (!stores.ContainsKey(store))
                    {
                        stores[store] = new List<string>();
                    }
                    foreach (var item in items)
                    {
                        stores[store].Add(item);
                    }
                   
                }
                else if (action == "Remove")
                {
                    if (stores.ContainsKey(store))
                    {
                        stores.Remove(store);
                    }
                }
            }
            stores = stores
                .OrderByDescending(x => x.Value.Count)
                .ThenByDescending(x => x.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine("Stores list: ");

            foreach (var store in stores)
            {
                Console.WriteLine(store.Key);

                store.Value.ForEach(x => Console.WriteLine($"<<{x}>>"));
            }
        }
    }
}
