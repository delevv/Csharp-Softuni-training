using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PostOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] parts = Console.ReadLine().Split("|");

            string firstPartPattern = @"([#\$%\*\&])([A-Z]+)\1";
            string secondPartPattern = @"\d{2}:\d{2}";

            var lettersAndCount = new Dictionary<char, int>();

            var letters = Regex.Match(parts[0], firstPartPattern).Groups[2].ToString();

            foreach (var letter in letters)
            {
                lettersAndCount[letter] = 1;
            }

            var lettersInfo = Regex.Matches(parts[1], secondPartPattern);

            foreach (Match item in lettersInfo)
            {
                string[] info = item.Value.Split(":");
                char currentLetter = (char)int.Parse(info[0]);
                int count = int.Parse(info[1]);

                if (lettersAndCount.ContainsKey(currentLetter) && lettersAndCount[currentLetter] == 1)
                {
                    lettersAndCount[currentLetter] += count;
                }
            }
            string thirdPart = parts[2];

            foreach (var kvp in lettersAndCount)
            {
                char letter = kvp.Key;
                int count = kvp.Value;
                string thirdPartPattern = @"(^|(?<=\s))[" + letter + @"][^\s]{" + (count - 1) + @"}\b";

                var matchedWords = Regex.Matches(thirdPart, thirdPartPattern);

                foreach (Match word in matchedWords)
                {
                    Console.WriteLine(word.Value);
                }
            }
        }
    }
}
