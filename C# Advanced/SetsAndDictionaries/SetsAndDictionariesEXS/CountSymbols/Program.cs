using System;
using System.Collections.Generic;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var symbols = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                var currentSymbol = text[i];

                if (!symbols.ContainsKey(currentSymbol))
                {
                    symbols[currentSymbol] = 1;
                }
                else
                {
                    symbols[currentSymbol]++;
                }
            }
            foreach (var (symbol,symbolCount) in symbols)
            {
                Console.WriteLine($"{symbol}: {symbolCount} time/s");
            }
        }
    }
}
