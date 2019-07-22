using System;
using System.Collections.Generic;
using System.Linq;
namespace SantasList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split("&").ToList();

            string command;

            while((command=Console.ReadLine())!= "Finished!")
            {
                string[] commandToArray = command.Split();

                string action = commandToArray[0];
                string kidName = commandToArray[1];

                if (action == "Bad")
                {
                    if (!names.Contains(kidName))
                    {
                        names.Insert(0, kidName);
                    }
                }
                else if (action == "Good")
                {
                    if (names.Contains(kidName))
                    {
                        names.Remove(kidName);
                    }
                }
                else if (action == "Rename")
                {
                    string newName = commandToArray[2];

                    if (names.Contains(kidName))
                    {
                        names[names.IndexOf(kidName)] = newName;
                    }
                }
                else if (action == "Rearrange")
                {
                    if (names.Contains(kidName))
                    {
                        names.Remove(kidName);
                        names.Add(kidName);
                    }
                }
            }
            Console.WriteLine(string.Join(", ",names));
        }
    }
}
