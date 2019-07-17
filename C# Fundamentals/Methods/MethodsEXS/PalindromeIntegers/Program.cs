using System;

namespace PalindromeIntegers
{
    class Program
    {
        static void IsPalidrome(int num,string command)
        {
            int number = num;
            int reversedNumber = 0;
           for(int i=command.Length;i>0;i--)
            {
                reversedNumber += number % 10 * (int)Math.Pow(10, i-1);
                number /= 10;
            }
            if (num == reversedNumber) Console.WriteLine("true");
            else Console.WriteLine("false");
        }
        static void Main(string[] args)
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                int num = int.Parse(command);
                IsPalidrome(num,command);
            }
        }
    }
}
