using System;

namespace AddAndSubstract
{
    class Program
    {
        static int Sum(int num1,int num2)
        {
            return num1 + num2;
        }
        static int Subtract(int sum,int num)
        {
            return sum - num;
        }
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int sumOfTwo = Sum(num1, num2);
            int result = Subtract(sumOfTwo, num3);
            Console.WriteLine(result);
        }
    }
}
