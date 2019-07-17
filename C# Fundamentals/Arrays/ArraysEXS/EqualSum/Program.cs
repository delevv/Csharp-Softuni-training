using System;
using System.Linq;

namespace EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int leftSum = 0;
            int rightSum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                leftSum = 1;
                rightSum = 1;
                int currentIndex = 0;
                while (currentIndex<i)
                {
                    leftSum += numbers[currentIndex];
                    currentIndex++;
                }
                currentIndex = numbers.Length-1;
                while (currentIndex >i)
                {
                    rightSum += numbers[currentIndex];
                    currentIndex--;
                }
                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
            if (leftSum != rightSum && numbers.Length>1) Console.WriteLine("no");
          
        }
    }
}
