using System;

namespace CharactersInRange
{
    class Program
    {
        static void PrintCharsInRange(char first,char second)
        {
            if (first>second)
            {
                while (second != first)
                {
                    second++;
                    if (first == second) break;
                    Console.Write(second + " ");
                }
            }
            else
            {
                while (first != second)
                {
                    first++;
                    if (first == second) break;
                    Console.Write(first + " ");
                }
            }
        }
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            PrintCharsInRange(first, second);
        }
    }
}
