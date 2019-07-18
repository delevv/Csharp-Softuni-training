using System;
using System.Collections.Generic;

namespace CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            var dict = new Dictionary<char, int>();

            foreach (var symbol in text)
            {
                if(symbol!=' ')
                {
                    if (!dict.ContainsKey(symbol))
                    {
                        dict[symbol] = 0;
                    }
                    dict[symbol]++;
                }
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
