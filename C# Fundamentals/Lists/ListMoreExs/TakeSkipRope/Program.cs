using System;
using System.Collections.Generic;
using System.Linq;

namespace TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            List<char> numbers = new List<char>();
            List<char> nonNumbers = new List<char>();

            for (int i = 0; i < text.Length; i++)
            {
                switch (text[i])
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        numbers.Add(text[i]);
                        break;
                    default:
                        nonNumbers.Add(text[i]);
                        break;
                }
            }
            List<char> taken = new List<char>();
            List<char> skip = new List<char>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    taken.Add(numbers[i]);
                }
                else
                {
                    skip.Add(numbers[i]);
                }
            }
            string result = "";
            int index = 0;

            for (int i = 0; i < skip.Count; i++)
            {
                int countOfTaken = taken[i] - '0';
                int countOfSkip = skip[i] - '0';

                for (int j = index; j < countOfTaken + index; j++)
                {
                    result += nonNumbers[j];
                }
                index += countOfSkip + countOfTaken;
            }
            Console.WriteLine(result);
        }
    }
}
