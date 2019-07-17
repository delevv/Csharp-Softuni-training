using System;

namespace TopNumber
{
    class Program
    {
        static void PrintTopNumbers(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                bool isOdd = false;
                int sum = 0;
                int currentNum = i;
                while (currentNum > 0)
                {
                    int currentDigit = currentNum % 10;
                    if (currentDigit % 2 == 1) isOdd = true;
                    sum += currentDigit;
                    currentNum /= 10;
                }
                if (sum % 8 == 0 && isOdd)
                {
                    Console.WriteLine(i);
                }
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintTopNumbers(n);
        }
    }
}
