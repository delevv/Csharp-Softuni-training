using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input;

            while ((input = Console.ReadLine()) !="end")
            {
                string[] arrayInput = input.Split().ToArray();

                if (arrayInput[0] == "Delete")
                {
                    int number = int.Parse(arrayInput[1]);
                    while (numbers.Contains(number))
                    {
                        numbers.Remove(number);
                    }
                }
                else if (arrayInput[0] == "Insert")
                {
                    numbers.Insert(int.Parse(arrayInput[2]), int.Parse(arrayInput[1]));
                }
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
