using System;

namespace LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char firstLetter = input[i][0];
                char lastLetter = input[i][input[i].Length - 1];
                double number = double.Parse(input[i].Substring(1, input[i].Length - 2));

                if (char.IsUpper(firstLetter))
                {
                    number /= firstLetter - 'A' + 1;
                }
                else
                {
                    number *= firstLetter - 'a' + 1;
                }
                if (char.IsUpper(lastLetter))
                {
                    number -= lastLetter - 'A' + 1;
                }
                else
                {
                    number += lastLetter - 'a' + 1;
                }
                sum += number;
            }
            Console.WriteLine(sum.ToString("f2"));
        }
    }
}
