using System;

namespace RecursiveFibonachi
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] array = new int[number];
            if (number == 1)
            {
                array[0] = 1;
            }
            else
            {
                array[0] = 1;
                array[1] = 1;
            }

            for (int i = 2; i < array.Length; i++)
            {
                array[i] = array[i - 2] + array[i - 1];
            }
            Console.WriteLine(array[number-1]);
        }
    }
}
