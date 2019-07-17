using System;
using System.Linq;

namespace RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().ToArray();

            Random rnd = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                string remaind = words[i];
                int currIndex = rnd.Next(0, words.Length - 1);
                words[i] = words[currIndex];
                words[currIndex] = remaind;
            }
            foreach (var item in words)
            {
                Console.WriteLine(item);
            }
        }
    }
}
