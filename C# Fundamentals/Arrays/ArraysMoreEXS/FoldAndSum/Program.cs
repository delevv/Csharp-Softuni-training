using System;
using System.Linq;

namespace FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] outside = new int[numbers.Length / 2];
            int[] inside = new int[numbers.Length / 2];
            int index = 0;
            for (int i = numbers.Length/4-1; i >=0; i--)
            {
                outside[index] = numbers[i];
                index++;
            }
            for (int k = numbers.Length-1; k >= numbers.Length-numbers.Length/4; k--)
            {
                outside[index] = numbers[k];
                index++;
            }
            index = 0;
            for (int j = numbers.Length/4; j < numbers.Length-numbers.Length/4; j++)
            {
                inside[index] = numbers[j];
                index++;
            }
            int[] result =new int[numbers.Length / 2];
            for (int m = 0; m < result.Length; m++)
            {
                result[m] = outside[m] + inside[m];
            }
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
