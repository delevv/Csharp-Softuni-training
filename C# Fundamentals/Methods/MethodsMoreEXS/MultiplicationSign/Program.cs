using System;

namespace MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            int negative = 0;
            int zero = 0;

            for (int i = 0; i < 3; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < 0) negative++;
                else if (num == 0) zero++;
            }
            if (zero > 0) Console.WriteLine("zero");
            else if (negative == 1 || negative == 3)
            {
                Console.WriteLine("negative");
            }
            else
            {
                Console.WriteLine("positive");
            }
        }
    }
}
