using System;
using System.IO;

namespace MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"..\..\..\FileOne.txt"))
            using (var secondReader = new StreamReader(@"..\..\..\FileTwo.txt"))
            using (var writer = new StreamWriter(@"..\..\..\output.txt"))
            {
                while (!reader.EndOfStream && !secondReader.EndOfStream)
                {
                    var currentLine = reader.ReadLine();
                    writer.WriteLine(currentLine);

                    currentLine = secondReader.ReadLine();
                    writer.WriteLine(currentLine);
                }
            }
        }
    }
}
