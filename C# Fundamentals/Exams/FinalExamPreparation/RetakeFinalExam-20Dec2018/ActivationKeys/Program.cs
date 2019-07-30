using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace ActivationKeys
{
    class Program
    {
        static string SplitCode(string text, int index, string symbol)
        {
            int startIndex = index;
            for (int i = 1; i <= startIndex-1; i++)
            {
                text = text.Insert(index, "-");
                index += startIndex + 1;
            }
            return text;
        }
        static string ChangeDigits(string text)
        {
            string result = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    result += 9 - (text[i] - '0');
                }
                else
                {
                    result += text[i];
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("&");
            var codes = new List<string>();

            string shortPattern = @"^[a-zA-Z0-9]{16}$";
            string longPattern = @"^[a-zA-Z0-9]{25}$";

            foreach (var code in input)
            {
                var shortMatch = Regex.Match(code, shortPattern);
                var longMatch = Regex.Match(code, longPattern);

                if (shortMatch.Success)
                {
                    string result = shortMatch.ToString().ToUpper();
                    result = SplitCode(result, 4, "-");
                    string decodedResult = ChangeDigits(result);
                    codes.Add(decodedResult);
                }
                else if (longMatch.Success)
                {
                    string result = longMatch.ToString().ToUpper();
                    result = SplitCode(result, 5, "-");
                    string decodedResult = ChangeDigits(result);
                    codes.Add(decodedResult);
                }
            }
            Console.WriteLine(string.Join(", ", codes));
        }
    }
}
