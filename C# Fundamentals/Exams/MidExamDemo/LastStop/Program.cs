using System;
using System.Collections.Generic;
using System.Linq;

namespace LastStop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> paintingNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] array = command.Split().ToArray();

                if (array[0] == "Change")
                {
                    int number = int.Parse(array[1]);

                    if (paintingNumbers.Contains(number))
                    {
                        int index = paintingNumbers.IndexOf(number);

                        paintingNumbers[index] = int.Parse(array[2]);
                    }
                }
                else if (array[0] == "Hide")
                {
                    int number = int.Parse(array[1]);

                    if (paintingNumbers.Contains(number))
                    {
                        paintingNumbers.Remove(number);
                    }
                }
                else if (array[0] == "Switch")
                {
                    int number = int.Parse(array[1]);

                    int secondNumber = int.Parse(array[2]);
                    if(paintingNumbers.Contains(number) && paintingNumbers.Contains(secondNumber))
                    {
                        int index1 = paintingNumbers.IndexOf(number);
                        int index2 = paintingNumbers.IndexOf(secondNumber);

                        paintingNumbers[index1] = secondNumber;
                        paintingNumbers[index2] = number;
                    }
                }
                else if (array[0] == "Insert")
                {
                    int number = int.Parse(array[1]);
                    int index = number + 1;
                    int currentNum = int.Parse(array[2]);

                    if (index>=0 && index < paintingNumbers.Count)
                    {
                        paintingNumbers.Insert(index, currentNum);
                    }
                }
                else if (array[0] == "Reverse")
                {
                    paintingNumbers.Reverse();
                }
            }
            Console.WriteLine(string.Join(" ",paintingNumbers));
        }
    }
}
