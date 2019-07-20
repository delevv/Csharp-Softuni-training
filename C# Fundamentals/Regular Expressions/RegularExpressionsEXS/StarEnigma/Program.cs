using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int messagesCount = int.Parse(Console.ReadLine());
            var attackedPlanets = new List<string>();
            var destroyedPlanets = new List<string>();

            for (int i = 0; i < messagesCount; i++)
            {
                string encryptedMessage = Console.ReadLine();
                var sb = new StringBuilder();
                string specialLetters = @"S|T|A|R|s|t|a|r";
                int lettersCount = Regex.Matches(encryptedMessage, specialLetters).Count;

                for (int j = 0; j < encryptedMessage.Length; j++)
                {
                    char symbol = (char)(encryptedMessage[j] - lettersCount);
                    sb.Append(symbol);
                }
                string message = sb.ToString();
                string pattern = @"@(?<name>[A-Z]*[a-z]*)[^@\-!:>]*:+(?<population>[0-9]+)[^@\-!:>]*!(?<type>A|D)![^@\-!:>]*->(?<soldierCount>\d+)";

                if (Regex.IsMatch(message, pattern))
                {
                    var validMessage = Regex.Match(message, pattern);
                    string planetName = validMessage.Groups["name"].Value;
                    string type = validMessage.Groups["type"].Value;

                    if (type == "A")
                    {
                        attackedPlanets.Add(planetName);
                    }
                    else
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }            
            }
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            attackedPlanets
                .OrderBy(x=>x)
                .ToList()
                .ForEach(x => Console.WriteLine($"-> {x}"));

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            destroyedPlanets
               .OrderBy(x => x)
               .ToList()
               .ForEach(x => Console.WriteLine($"-> {x}"));
        }
    }
}
