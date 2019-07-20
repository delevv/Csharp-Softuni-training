using System;
using System.Text.RegularExpressions;

namespace ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(^|(?<=\s))([a-z]|[0-9])+[\.\-_]?[a-z]*\d*@[a-z]+-?[a-z]*\.[a-z]+\.?[a-z]+";

            var matchedWords = Regex.Matches(input, pattern);

            foreach (Match word in matchedWords)
            {
                Console.WriteLine(word.Value);
            }
        }
    }
}
