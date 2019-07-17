using System;

namespace FactorialDivision
{
    class Program
    {
        static double Factorial(int num)
        {
            double sum = 1;
            for (int i = 2; i <= num; i++)
            {
                sum *= i;
            }
            return sum;
        }
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            double result =Factorial(num1)/Factorial(num2);
            Console.WriteLine($"{result:f2}");
        }
    }
}
