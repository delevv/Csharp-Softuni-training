using System;

namespace SmallestOfThreeNumbers
{
    class Program
    {
        static void PrintSmallestNumber()
        {
            int smallestNum = int.MaxValue;
            for (int i = 0; i < 3; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                if (currentNum < smallestNum) smallestNum = currentNum;
            }
            Console.WriteLine(smallestNum);
        }
        static void Main(string[] args)
        {
            PrintSmallestNumber();
        }
    }
}
