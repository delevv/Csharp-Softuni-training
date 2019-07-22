using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestsJournal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> journal = Console.ReadLine().Split(", ").ToList();

            string command;

            while ((command = Console.ReadLine()) != "Retire!")
            {
                string[] commandToArray = command.Split(" - ");
                string quest = commandToArray[1];

                if (commandToArray[0] == "Start")
                {
                    if (!journal.Contains(quest))
                    {
                        journal.Add(quest);
                    }
                }
                else if (commandToArray[0] == "Complete")
                {
                    if (journal.Contains(quest))
                    {
                        journal.Remove(quest);
                    }
                }
                else if(commandToArray[0]=="Side Quest")
                {
                    string[] questToArray = quest.Split(":");
                    quest = questToArray[0];
                    string sideQuest = questToArray[1];

                    if (journal.Contains(quest))
                    {
                        int index = journal.IndexOf(quest);
                        if (!journal.Contains(sideQuest))
                        {
                            journal.Insert(index + 1, sideQuest);
                        }
                    }
                }
                else if (commandToArray[0] == "Renew")
                {
                    if (journal.Contains(quest))
                    {
                        journal.Remove(quest);
                        journal.Add(quest);
                    }
                }
            }
            Console.WriteLine(string.Join(", ",journal));
        }
    }
}
