using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] previousArray = new int[number];
            previousArray[0] = 1;
            for (int i = 1; i <= number; i++)
            {
                int[] array = new int[i];
                array[0] = 1;
                for (int j = 1; j < array.Length; j++)
                {
                    array[j] = previousArray[j-1] + previousArray[j];
                }
                for (int k = 0; k < array.Length; k++)
                {
                    previousArray[k] = array[k];
                }
                Console.WriteLine(string.Join(" ",array));
            }
        }
    }
}
