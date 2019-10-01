using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = long.Parse(Console.ReadLine());

            var jaggedArray = new long[number][];

            for (int i = 0; i < number; i++)
            {
                jaggedArray[i] = new long[i+1];
                jaggedArray[i][0] = 1;

                for (int j = 1; j < i; j++)
                {
                    jaggedArray[i][j] = jaggedArray[i - 1][j - 1] + jaggedArray[i - 1][j];
                }
                jaggedArray[i][jaggedArray[i].Length - 1] = 1;
            }
            foreach (var array in jaggedArray)
            {
                Console.WriteLine(string.Join(" ",array));
            }
        }
    }
}
