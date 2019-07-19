using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Race
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(", ").ToList();
            var namesAndPoints = new Dictionary<string, int>();
            string command;

            while((command=Console.ReadLine())!="end of race")
            {
                string lettersPattern = @"[a-z]|[A-Z]";
                var letters = Regex.Matches(command, lettersPattern);
                string name = "";

                foreach (Match letter in letters)
                {
                    name += letter.Value;
                }
                if (names.Contains(name))
                {
                    string digitsPattern = @"[0-9]";
                    var digits = Regex.Matches(command, digitsPattern);
                    int points = 0;

                    foreach (Match digit in digits)
                    {
                        points += int.Parse(digit.Value);
                    }
                    if (!namesAndPoints.ContainsKey(name))
                    {
                        namesAndPoints[name] = 0;
                    }
                        namesAndPoints[name] += points;
                }
            }
            var winners = namesAndPoints
                .OrderByDescending(x => x.Value)
                .Take(3)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
                .Keys
                .ToList();

            Console.WriteLine($"1st place: {winners[0]}");
            Console.WriteLine($"2nd place: {winners[1]}");
            Console.WriteLine($"3rd place: {winners[2]}");
        }
    }
}
