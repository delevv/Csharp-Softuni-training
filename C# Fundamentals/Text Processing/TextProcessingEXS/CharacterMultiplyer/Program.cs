using System;

namespace CharacterMultiplyer
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            int sum = 0;

            for (int i = 0; i < Math.Max(words[0].Length,words[1].Length); i++)
            {
                int firstNumber = 1;
                int secondNumber = 1;

                if (i < words[0].Length)
                {
                    firstNumber = words[0][i];
                }
                if (i < words[1].Length)
                {
                    secondNumber = words[1][i];
                }
                sum += firstNumber * secondNumber;
            }
            Console.WriteLine(sum);
        }
    }
}
