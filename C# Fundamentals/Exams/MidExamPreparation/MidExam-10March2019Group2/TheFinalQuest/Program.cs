using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFinalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> text = Console.ReadLine().Split().ToList();

            string command = Console.ReadLine();

            while (command != "Stop")
            {
                List<string> commandToList = command.Split().ToList();

                if (commandToList[0] == "Delete")
                {
                    int index = int.Parse(commandToList[1])+1;
                    if (index >= 0 && index < text.Count)
                    {
                        text.RemoveAt(index);
                    }
                }
                else if (commandToList[0] == "Swap")
                {
                    string word1 = commandToList[1];
                    string word2 = commandToList[2];

                    if (text.Contains(word1) && text.Contains(word2))
                    {
                        int index1 = text.IndexOf(word1);
                        int index2 = text.IndexOf(word2);

                        text[index1] = word2;
                        text[index2] = word1;
                    }
                }
                else if (commandToList[0] == "Put")
                {
                    string word = commandToList[1];
                    int index = int.Parse(commandToList[2])-1;

                    if (index >=0 && index <= text.Count)
                    {
                        text.Insert(index, word);
                    }
                }
                else if (commandToList[0] == "Sort")
                {
                    text.Sort();
                    text.Reverse();
                }
                else if (commandToList[0] == "Replace")
                {
                    string word1 = commandToList[1];
                    string word2 = commandToList[2];
                    if (text.Contains(word2))
                    {
                        int index = text.IndexOf(word2);
                        text[index] = word1;
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", text));
        }
    }
}
