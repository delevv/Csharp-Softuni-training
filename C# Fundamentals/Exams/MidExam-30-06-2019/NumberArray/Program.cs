using System;
using System.Collections.Generic;
using System.Linq;

namespace Exs2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] arr = command.Split();

                if (arr[0] == "Switch")
                {
                    int index = int.Parse(arr[1]);
                    if(index>=0 && index < numbers.Count)
                    {
                        int number = numbers[index];
                        number *= -1;
                        numbers[index] = number;
                    }
                }
                else if (arr[0] == "Change")
                {
                    int index = int.Parse(arr[1]);
                    int value = int.Parse(arr[2]);

                    if(index>=0 && index < numbers.Count)
                    {
                        numbers[index] = value;
                    }
                }
                else if(arr[0]=="Sum")
                {
                    int positiveSum = 0;
                    int negativeSum = 0;

                    foreach (var number in numbers)
                    {
                        if (number < 0)
                        {
                            negativeSum += number;
                        }
                        else
                        {
                            positiveSum += number;
                        }
                    }
                    if (arr[1] == "Negative")
                    {
                        Console.WriteLine(negativeSum);
                    }
                    else if (arr[1] == "Positive")
                    {
                        Console.WriteLine(positiveSum);
                    }
                    else if (arr[1] == "All")
                    {
                        Console.WriteLine(numbers.Sum());
                    }
                }
            }
            foreach (var number in numbers)
            {
                if (number >= 0)
                {
                    Console.Write(number+ " ");
                }
            }
        }
    }
}
