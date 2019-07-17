using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
{
    class Program
    {
        static void ShiftLeftOrRight(List<int> numbers,int count,string leftOrRight)
        {
            if (leftOrRight == "right")
            {
                for (int i = 0; i < count; i++)
                {
                    numbers.Insert(0, numbers[numbers.Count - 1]);
                    numbers.RemoveAt(numbers.Count - 1);
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    numbers.Add(numbers[0]);
                    numbers.RemoveAt(0);
                }
            }
        }
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] arrayInput = input.Split().ToArray();

                if (arrayInput[0] == "Add")
                {
                    numbers.Add(int.Parse(arrayInput[1]));
                }
                else if (arrayInput[0] == "Insert")
                {
                    int index = int.Parse(arrayInput[2]);
                    if (index >= 0 && index < numbers.Count)
                    {
                        numbers.Insert(index, int.Parse(arrayInput[1]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (arrayInput[0] == "Remove")
                {
                    int index = int.Parse(arrayInput[1]);
                    if (index >= 0 && index < numbers.Count)
                    {
                        numbers.RemoveAt(index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (arrayInput[0]=="Shift")
                {
                    ShiftLeftOrRight(numbers, int.Parse(arrayInput[2]), arrayInput[1]);
                }
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
