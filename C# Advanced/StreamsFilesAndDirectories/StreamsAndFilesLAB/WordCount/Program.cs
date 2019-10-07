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
            using (var readWords = new StreamReader(@"..\..\..\words.txt"))
            using (var readText = new StreamReader(@"..\..\..\text.txt"))
            using (var writer = new StreamWriter(@"..\..\..\output.txt"))
            {
                var words = new List<string>();

                while (!readWords.EndOfStream)
                {
                    words.AddRange(readWords.ReadLine().ToLower().Split());
                }

                var textLines = new List<string>();

                while (!readText.EndOfStream)
                {
                    textLines.Add(readText.ReadLine().ToLower());
                }

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
                foreach (var kvp in matchedWords.OrderByDescending(x=>x.Value))
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }
        }
    }
}
