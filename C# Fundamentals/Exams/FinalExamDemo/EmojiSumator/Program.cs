using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace EmojiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            var emojiCodes = Console.ReadLine().Split(":").Select(int.Parse).ToList();

            string emojiPattern = @"(?<=[\s])(:[a-z]{4,}:)(?=[\s,.!?])";

            var validEmoji = Regex.Matches(text, emojiPattern).Cast<Match>().Select(m => m.Groups[1].Value).ToList();

            int totalEmojiPower = 0;

            foreach (var emoji in validEmoji)
            {
                foreach (var symbol in emoji)
                {
                    if (symbol != ':')
                    {
                        totalEmojiPower += symbol;
                    }
                }
            }
            string specialEmoji = ":";

            foreach (var code in emojiCodes)
            {
                specialEmoji += (char)code;
            }
            specialEmoji += ":";

            if (validEmoji.Contains(specialEmoji))
            {
                totalEmojiPower *= 2;
            }
            if (validEmoji.Count > 0)
            {
                Console.WriteLine($"Emojis found: {string.Join(", ", validEmoji)}");
            }
            Console.WriteLine($"Total Emoji Power: {totalEmojiPower}");
        }
    }
}