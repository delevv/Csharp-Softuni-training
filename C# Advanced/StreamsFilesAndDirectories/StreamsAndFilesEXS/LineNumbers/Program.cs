using System;
using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"..\..\..\text.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                var currentLine = lines[i];

                var lettersCount = 0;
                var punctuationCount = 0;

                foreach (var symbol in currentLine)
                {
                    if (char.IsLetter(symbol))
                    {
                        lettersCount++;
                    }
                    else if (symbol != ' ')
                    {
                        punctuationCount++;
                    }
                }
                File.AppendAllText(@"..\..\..\output.txt",$"Line {i + 1}: {currentLine} ({lettersCount})({punctuationCount})"+Environment.NewLine);
            }
        }
    }
}
