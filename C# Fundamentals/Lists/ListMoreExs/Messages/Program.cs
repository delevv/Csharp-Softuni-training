using System;
using System.Collections.Generic;
using System.Linq;

namespace Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string text = Console.ReadLine();

            List<char> listOfCharacters = new List<char>();

            for (int i = 0; i < text.Length; i++)
            {
                listOfCharacters.Add(text[i]);
            }
            string message = "";
            for (int i = 0; i < numbers.Count; i++)
            {
                int number = numbers[i];
                int sumOfDigits = 0;
              
                while (number > 0)
                {
                    int currentDigit = number % 10;
                    sumOfDigits += currentDigit;
                    number /= 10;
                }
                for (int j = 0; j < listOfCharacters.Count; j++)
                {
                    if (sumOfDigits == j)
                    {
                        message += listOfCharacters[j];
                        listOfCharacters.RemoveAt(j);
                        break;
                    }

                    if (j == listOfCharacters.Count-1)
                    {
                        j = 0;
                        sumOfDigits -= listOfCharacters.Count;
                    }
                }
            }
            Console.WriteLine(message);
        }
    }
}
