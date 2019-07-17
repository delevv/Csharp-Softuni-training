using System;

namespace MultiplyEvensByOdds
{
    class Program
    {
        static int MultiplyOfEvensAndOddsSum(int number)
        {
            int oddSum = 0;
            int evenSum = 0;
            while (number > 0)
            {
                int currentDigit = number % 10;
                number /= 10;
                if (currentDigit % 2 == 0) evenSum += currentDigit;
                else oddSum += currentDigit;
            }
            return oddSum*evenSum;
        }
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            number = Math.Abs(number);
            Console.WriteLine(MultiplyOfEvensAndOddsSum(number));
        }
    }
}
