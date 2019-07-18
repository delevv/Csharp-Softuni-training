using System;

namespace AsciiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstSymbol = char.Parse(Console.ReadLine());
            char secondSymbol = char.Parse(Console.ReadLine());

            string text = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char currentSymbol = text[i];
                if(currentSymbol>firstSymbol && currentSymbol < secondSymbol)
                {
                    sum += currentSymbol;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
