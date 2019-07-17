using System;

namespace MathOperations
{
    class Program
    {
        static double CalculateNumbers(int num1,string sign,int num2)
        {
            double result = 0;
            switch (sign)
            {
                case "+": result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = num1 / (double)num2;
                    break;
            }
            return result;
        }
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            string sign = Console.ReadLine();
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine($"{CalculateNumbers(num1, sign, num2)}");
        }
    }
}
