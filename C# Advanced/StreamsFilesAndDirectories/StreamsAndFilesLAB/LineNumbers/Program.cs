using System;
using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"..\..\..\Input.txt"))
            using (var writer = new StreamWriter(@"..\..\..\output.txt"))
            {
                var lineNumber = 1;

                while (!reader.EndOfStream)
                {
                    var currentLine = reader.ReadLine();
                    writer.WriteLine($"{lineNumber++}. {currentLine}");
                }
            }
        }
    }
}
