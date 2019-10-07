using System;
using System.IO;
using System.Collections.Generic;

namespace OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var writer=new StreamWriter(@"..\..\..\output.txt"))
            using (var reader = new StreamReader(@"..\..\..\input.txt"))
            {
                var lineCounter = 0;

                while (!reader.EndOfStream)
                {
                    var currentLine = reader.ReadLine();

                    if (lineCounter % 2 == 1)
                    {
                        writer.WriteLine(currentLine);
                    }
                    lineCounter++;
                }
            }
        }
    }
}
