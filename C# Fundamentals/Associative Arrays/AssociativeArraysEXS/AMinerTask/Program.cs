using System;
using System.Collections.Generic;

namespace AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, int>();
            string command;

            while ((command = Console.ReadLine()) != "stop")
            {
                string type = command;
                int count = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(type))
                {
                    dict[type] = 0;
                }
                dict[type] += count;
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
