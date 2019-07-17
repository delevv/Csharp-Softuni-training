using System;

namespace SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfLines = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < countOfLines; i++)
            {
                char currentChar = char.Parse(Console.ReadLine());
                sum += currentChar;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
