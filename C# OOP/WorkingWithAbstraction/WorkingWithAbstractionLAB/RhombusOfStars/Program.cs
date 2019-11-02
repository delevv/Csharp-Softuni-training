using System;

namespace RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            var figureSize = int.Parse(Console.ReadLine());

            for (int starsCount = 1; starsCount <= figureSize; starsCount++)
            {
                PrintRow(figureSize, starsCount);
                Console.WriteLine();
            }
         
            for (int starsCount = figureSize-1; starsCount >= 1; starsCount--)
            {
                PrintRow(figureSize, starsCount);
                Console.WriteLine();
            }
        }
        static void PrintRow(int figureSize,int starsCount)
        {
            Console.Write(new string (' ',figureSize-starsCount));

            for (int i = 0; i < starsCount; i++)
            {
                Console.Write("* ");
            }
        }
    }
}
