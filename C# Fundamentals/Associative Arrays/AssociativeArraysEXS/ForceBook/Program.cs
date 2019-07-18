using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var sides = new Dictionary<string, List<string>>();
            string command;

            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                string forceSide;
                string forceUser;

                if (command.Contains('|'))
                {
                    string[] info = command.Split(" | ");

                    forceSide = info[0];
                    forceUser = info[1];

                    if (!sides.ContainsKey(forceSide))
                    {
                        sides[forceSide] = new List<string>();
                    }
                    bool isUserExists = false;
                    foreach (var side in sides)
                    {
                        if (side.Value.Contains(forceUser))
                        {
                            isUserExists = true;
                            break;
                        }
                    }
                    if (!sides[forceSide].Contains(forceUser) && !isUserExists)
                    {
                        sides[forceSide].Add(forceUser);
                    }
                }
                else
                {
                    string[] info = command.Split(" -> ");

                    forceSide = info[1];
                    forceUser = info[0];

                    bool isUserExists = false;
                    string currentSide = "";

                    foreach (var side in sides)
                    {
                        if (side.Value.Contains(forceUser))
                        {
                            currentSide = side.Key;
                            isUserExists = true;
                            break;
                        }
                    }
                    if (isUserExists)
                    {
                        sides[currentSide].Remove(forceUser);
                    }
                    if (!sides.ContainsKey(forceSide))
                    {
                        sides[forceSide] = new List<string>();
                    }
                    if (!sides[forceSide].Contains(forceUser))
                    {
                        sides[forceSide].Add(forceUser);
                    }
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }

            sides = sides.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var side in sides)
            {
                if (side.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                    side.Value.OrderBy(x => x).ToList().ForEach(x => Console.WriteLine($"! {x}"));
                }
            }
        }
    }
}
