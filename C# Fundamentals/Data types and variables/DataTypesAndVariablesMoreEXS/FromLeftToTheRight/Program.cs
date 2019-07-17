using System;

namespace FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int spaceDigit = 0;
                string numbers = Console.ReadLine();
                string left = "";

                for (int j = 0; j < numbers.Length; j++)
                {
                    left += numbers[j];
                    if(numbers[j]==' ')
                    {
                        spaceDigit = j;
                        break;
                    }
                }

                string right = "";

                for (int k = spaceDigit+1; k < numbers.Length; k++)
                {
                    right += numbers[k];
                }

                long leftNumber =long.Parse(left);
                long rightNumber = long.Parse(right);
                long biggestNumber = Math.Abs(Math.Max(leftNumber,rightNumber));
                long sum = 0;
                while (biggestNumber > 0)
                {
                    long currentDigit = biggestNumber % 10;
                    biggestNumber /= 10;
                    sum += currentDigit;
                }

                Console.WriteLine(sum);
            }
        }
    }
}
