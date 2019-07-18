using System;

namespace ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] path = Console.ReadLine().Split(@"\");
            string[] nameAndExtension = path[path.Length - 1].Split(".");
            Console.WriteLine($"File name: {nameAndExtension[0]}");
            Console.WriteLine($"File extension: {nameAndExtension[1]}");
        }
    }
}
