using System;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string word;

            while ((word = Console.ReadLine()) != "end")
            {
                string reversed = "";

                for (int i = word.Length-1; i >= 0; i--)
                {
                    reversed += word[i];
                }
                Console.WriteLine($"{word} = {reversed}");
            }
        }
    }
}
