using System;
using System.Collections.Generic;

namespace StringManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "";

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split();

                if (commandArgs[0] == "Add")
                {
                    string currentText = commandArgs[1];
                    text += currentText;
                }
                else if (commandArgs[0] == "Upgrade")
                {
                    char symbol = char.Parse(commandArgs[1]);
                    text = text.Replace(symbol, (char)(symbol + 1));
                }
                else if (commandArgs[0] == "Print")
                {
                    Console.WriteLine(text);
                }
                else if (commandArgs[0] == "Index")
                {
                    char symbol = char.Parse(commandArgs[1]);
                    var indexes = new List<int>();

                    for (int i = 0; i < text.Length; i++)
                    {
                        if (text[i] == symbol)
                        {
                            indexes.Add(i);
                        }
                    }
                    if (indexes.Count > 0)
                    {
                        Console.WriteLine(string.Join(" ",indexes));
                    }
                    else
                    {
                        Console.WriteLine("None");
                    }
                }
                else if (commandArgs[0] == "Remove")
                {
                    string currentText = commandArgs[1];

                    while (text.Contains(currentText))
                    {
                        int index = text.IndexOf(currentText);
                        text = text.Remove(index, currentText.Length);
                    }
                }
            }
        }
    }
}
