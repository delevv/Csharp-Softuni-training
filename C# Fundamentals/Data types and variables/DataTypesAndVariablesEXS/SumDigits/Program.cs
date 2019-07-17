using System;

namespace SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            while (num > 0)
            {
                int currentDigit = num % 10;
                num /= 10;
                sum += currentDigit;

            }
            Console.WriteLine(sum);
            
        }
    }
}
