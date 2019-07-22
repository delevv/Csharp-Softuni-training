using System;
using System.Collections.Generic;
using System.Linq;

namespace LastTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> paintings = Console.ReadLine().Split().Select(int.Parse).ToList();

            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0] != "END")
            {
                if (command[0] == "Change")
                {
                    int number = int.Parse(command[1]);
                    int changedNumber = int.Parse(command[2]);
                    if (paintings.Contains(number))
                    {
                        paintings[paintings.IndexOf(number)] = changedNumber;
                    }
                }
                else if (command[0] == "Hide")
                {
                    int number = int.Parse(command[1]);
                    if (paintings.Contains(number))
                    {
                        paintings.Remove(number);
                    }
                }
                else if (command[0] == "Switch")
                {
                    int firstNumber = int.Parse(command[1]);
                    int secondNumber = int.Parse(command[2]);
                    if (paintings.Contains(firstNumber) && paintings.Contains(secondNumber))
                    {
                        int firstIndex = paintings.IndexOf(firstNumber);
                        int secondIndex = paintings.IndexOf(secondNumber);

                        paintings[firstIndex] = secondNumber;
                        paintings[secondIndex] = firstNumber;
                    }
                }
                else if (command[0] == "Insert")
                {
                    int index = int.Parse(command[1]) + 1;
                    int number = int.Parse(command[2]);

                    if(index>=0 && index<paintings.Count)
                    {
                        paintings.Insert(index, number);
                    }
                }
                else if (command[0] == "Reverse")
                {
                    paintings.Reverse();
                }
                command = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine(string.Join(" ",paintings));
        }
    }
}
