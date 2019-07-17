using System;

namespace Calculations
{
    class Program
    {
        static void AddNumbers(int a,int b)
        {
            Console.WriteLine(a+b);
        }
        static void MultiplyNumbers(int a,int b)
        {
            Console.WriteLine(a*b);
        }
        static void SubtrackNumbers(int a, int b)
        {
            Console.WriteLine(a - b);
        }
        static void DivideNumbers(int a, int b)
        {
            Console.WriteLine(a / b);
        }
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            switch (command)
            {
                case "add": AddNumbers(num1, num2);
                    break;
                case "divide":
                    DivideNumbers(num1, num2);
                    break;
                case "subtrack":
                    SubtrackNumbers(num1, num2);
                    break;
                case "multiply":
                    MultiplyNumbers(num1, num2);
                    break;
            }
        }
    }
}
