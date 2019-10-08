using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = File.ReadAllLines(@"..\..\..\words.txt").Select(x => x.ToLower()).ToList();
            var textLines = File.ReadAllLines(@"..\..\..\text.txt").Select(x => x.ToLower()).ToList();

            var matchedWords = new Dictionary<string, int>();

            foreach (var line in textLines)
            {
                foreach (var word in words)
                {
                    if (line.Contains(word))
                    {
                        if (words.Contains(word))
                        {
                            if (!matchedWords.ContainsKey(word))
                            {
                                matchedWords[word] = 0;
                            }
                            matchedWords[word]++;
                        }
                    }
                }
            }

            foreach (var kvp in matchedWords.OrderByDescending(x => x.Value))
            {
                File.AppendAllText(@"..\..\..\actualResult.txt", $"{kvp.Key} - {kvp.Value}" + Environment.NewLine);
            }

            var actualResult = File.ReadAllLines(@"..\..\..\actualResult.txt");
            var expectedResult = File.ReadAllLines(@"..\..\..\expectedResult.txt");

            bool isEqual = actualResult.SequenceEqual(expectedResult);

            Console.WriteLine(isEqual);
        }
    }
}
