using System;

namespace ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string result = "";

            for (int i = 0; i < text.Length; i++)
            {
                char currentSymbol = text[i];
                string currentSequence = "";
                for (int j = i; j < text.Length; j++)
                {
                    if (currentSymbol == text[j])
                    {
                        currentSequence += text[j];
                    }
                    else
                    {
                        break;
                    }
                }
                text = text.Replace(currentSequence, currentSymbol.ToString());
            }
            Console.WriteLine(text);

        }
    }
}
