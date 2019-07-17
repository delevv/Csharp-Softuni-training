using System;

namespace MiddleCharacters
{
    class Program
    {
        static void PrintMiddleCharacter(string text)
        {
            if (text.Length % 2 == 0)
            {
                char mid = text[text.Length/2 - 1];
                char mid2 = text[text.Length/2];
                Console.WriteLine($"{mid}{mid2}");
            }
            else
            {
                char mid = text[text.Length/2];
                Console.WriteLine(mid);
            }
        }
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            PrintMiddleCharacter(text);
        }
    }
}
