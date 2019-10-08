using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            var symbols = new char[] { '-', ',', '.', '!', '?' };

            using (var reader = new StreamReader(@"..\..\..\text.txt"))
            {
                var counter = 0;

                while (!reader.EndOfStream)
                {
                    var currentLine = reader.ReadLine().Split().ToList();

                    if (counter % 2 == 0)
                    {
                        for (int i = 0; i < currentLine.Count; i++)
                        {
                            var currentWord = currentLine[i];
                            foreach (var symbol in symbols)
                            {
                                currentWord = currentWord.Replace(symbol, '@');
                                currentLine[i] = currentWord;


                            }
                        }
                        currentLine.Reverse();
                        Console.WriteLine(string.Join(" ", currentLine));
                    }
                    counter++;
                }
            }
        }
    }
}
