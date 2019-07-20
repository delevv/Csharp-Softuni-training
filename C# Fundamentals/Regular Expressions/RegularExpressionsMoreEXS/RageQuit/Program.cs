using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections.Generic;

namespace ExamPreparation
{
    public sealed class Preparation
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            var numbers = Regex.Matches(input, @"\d+").Cast<Match>().Select(m => m.Value).Select(int.Parse).ToArray();
            var word = Regex.Matches(input, @"\D+").Cast<Match>().Select(m => m.Value).ToArray();

            var symbols = new List<char>();
            var sb = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                string currentWord = word[i].ToUpper();
                int currentNumber = numbers[i];

                for (int j = 0; j < currentNumber; j++)
                {
                    sb.Append(currentWord);
                }
                if (currentNumber > 0)
                {
                    for (int k = 0; k < currentWord.Length; k++)
                    {
                        if (!symbols.Contains(currentWord[k]))
                        {
                            symbols.Add(currentWord[k]);
                        }
                    }
                }
            }
            Console.WriteLine($"Unique symbols used: {symbols.Count}");
            Console.WriteLine(sb);
           
            ////AnotherSolution
            
            // string input = Console.ReadLine();
            // string pattern = @"(([^\d]+)(\d+))";

            // var matches = Regex.Matches(input, pattern);
            // StringBuilder sb = new StringBuilder();

            // foreach (Match match in matches)
            // {
            //     string message = match.Groups[2].Value;
            //     int repeats = int.Parse(match.Groups[3].Value);

            //     for (int i = 0; i < repeats; i++)
            //     {
            //         sb.Append(message.ToUpper());
            //     }
            // }

            // int count = sb.ToString().Distinct().Count();

            // Console.WriteLine($"Unique symbols used: {count}");
            // Console.WriteLine(sb);
        }
    }
}