using System;
using System.Collections.Generic;
using System.Linq;

namespace AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();

            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0] != "3:1")
            {
                if (command[0] == "merge")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    if (endIndex > input.Count - 1) endIndex = input.Count - 1;
                    if (startIndex < 0 || startIndex > endIndex) startIndex = 0;

                    string merge = "";


                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        merge += input[startIndex];
                        input.RemoveAt(startIndex);
                    }
                    input.Insert(startIndex, merge);
                }
                else if (command[0] == "divide")
                {
                    int index = int.Parse(command[1]);
                    int parts = int.Parse(command[2]);
                    string element = input[index];
                    input.RemoveAt(index);

                    if (element.Length % parts == 0)
                    {
                        int countOfDigitsPerPart = element.Length / parts;
                        string currentElement = "";

                        for (int i = 0; i < element.Length; i++)
                        {
                            currentElement += element[i];
                            if ((i + 1) % countOfDigitsPerPart == 0)
                            {
                                input.Insert(index, currentElement);
                                currentElement = "";
                                index++;
                            }
                        }
                    }
                    else
                    {
                        int countOfDigitsPerPart = element.Length / parts;
                        string currentElement = "";

                        for (int i = 0; i < element.Length; i++)
                        {
                            if (i < element.Length - 1 - countOfDigitsPerPart)
                            {
                                currentElement += element[i];

                                if ((i + 1) % countOfDigitsPerPart == 0)
                                {
                                    input.Insert(index, currentElement);
                                    currentElement = "";
                                    index++;
                                }
                            }
                            else
                            {
                                currentElement += element[i];
                                if (i == element.Length - 1)
                                {
                                    input.Insert(index, currentElement);
                                }
                            }
                        }
                    }
                }
                command = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
