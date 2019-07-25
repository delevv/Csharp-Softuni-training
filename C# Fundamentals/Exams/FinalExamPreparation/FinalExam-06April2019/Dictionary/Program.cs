using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordsAndDescriptios = Console.ReadLine().Split(" | ");

            var dict = new Dictionary<string, List<string>>();

            for (int i = 0; i < wordsAndDescriptios.Length; i++)
            {
                string[] wordAndDescription = wordsAndDescriptios[i].Split(": ");

                string word = wordAndDescription[0];
                string description = wordAndDescription[1];

                if (!dict.ContainsKey(word))
                {
                    dict[word] = new List<string>();
                }
                dict[word].Add(description);
            }

            string[] words = Console.ReadLine().Split(" | ");

            foreach (var word in words)
            {
                if (dict.ContainsKey(word))
                {
                    Console.WriteLine($"{word}");

                    foreach (var description in dict[word].OrderByDescending(x=>x.Length))
                    {
                        Console.WriteLine($" -{description}");
                    }
                }
            }
            string command = Console.ReadLine();

            if (command == "List")
            {
                foreach (var word in dict.OrderBy(x=>x.Key))
                {
                    Console.Write(word.Key+" ");
                }
            }
        }
    }
}
