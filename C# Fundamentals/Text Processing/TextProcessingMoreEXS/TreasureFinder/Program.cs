using System;
using System.Linq;

namespace TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] keys = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string command;

            while ((command = Console.ReadLine()) != "find")
            {
                int keyIndex = 0;
                string text = "";

                for (int i = 0; i < command.Length; i++)
                {
                    text += (char)(command[i] - keys[keyIndex]);
                    keyIndex++;

                    if (keyIndex > keys.Length - 1)
                    {
                        keyIndex = 0;
                    }
                }
                string type = text.Split("&")[1];

                int coordStartIndex = text.IndexOf("<") + 1;
                int coordSymbolCount = text.IndexOf(">")-coordStartIndex;
                string coordinates = text.Substring(coordStartIndex, coordSymbolCount);

                Console.WriteLine($"Found {type} at {coordinates}");
            }
        }
    }
}
