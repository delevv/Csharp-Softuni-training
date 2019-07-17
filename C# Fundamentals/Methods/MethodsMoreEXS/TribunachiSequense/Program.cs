using System;

namespace TribunachiSequense
{
    class Program
    {
        static void PrintTribonacci(int count)
        {
            int[] tribonacci = new int[count];


            for (int i = 0; i < count; i++)
            {
                if (i < 2) tribonacci[i] = 1;
                else if (i < 3) tribonacci[i] = 2;
                else
                {
                    tribonacci[i] = tribonacci[i - 1] + tribonacci[i - 2] + tribonacci[i - 3];
                }

            }
            Console.WriteLine(string.Join(" ",tribonacci));
        }
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            PrintTribonacci(count);
        }
    }
}
