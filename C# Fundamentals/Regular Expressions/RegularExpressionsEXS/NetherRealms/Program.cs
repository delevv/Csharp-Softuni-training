using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            var demons = Console.ReadLine().Split(new char[] { ',', ' ' },StringSplitOptions.RemoveEmptyEntries).OrderBy(x => x).ToList();

            string healthPattern = @"[^\d\+\-\*\/\.,\s]";
            string damagePattern = @"[-|\+]?\d+\.?\d*";
            string specialSymbols = @"\*|\/";

            for (int i = 0; i < demons.Count; i++)
            {
                string name = demons[i];
  
                int health = 0;
                var matchedSymbols = Regex.Matches(name, healthPattern);

                foreach (Match symbol in matchedSymbols)
                {
                    health += char.Parse(symbol.Value);
                }
                double damage = 0;
                var matchedDigits = Regex.Matches(name, damagePattern);

                foreach (Match digit in matchedDigits)
                {
                    damage += double.Parse(digit.Value);
                }
                var matchedSpecialSymbols = Regex.Matches(name, specialSymbols);

                foreach (Match symbol in matchedSpecialSymbols)
                {
                    char currentSymbol = char.Parse(symbol.Value);

                    if (currentSymbol == '*')
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }
                Console.WriteLine($"{name} - {health} health, {damage:f2} damage");
            }
        }
    }
}
