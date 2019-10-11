using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyReservationFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            var guests = Console.ReadLine().Split().ToList();
            var filters = new List<string>();

            var command = "";

            while ((command = Console.ReadLine()) != "Print")
            {
                var commandArgs = command.Split(";");

                if (commandArgs[0] == "Add filter")
                {
                    filters.Add(commandArgs[1] + " " + commandArgs[2]);
                }
                else if (commandArgs[0] == "Remove filter")
                {
                    filters.Remove(commandArgs[1] + " " + commandArgs[2]);
                }

            }
            foreach (var filter in filters)
            {
                var commandArgs = filter.Split();

                if (commandArgs[0] == "Starts")
                {
                    guests = guests.Where(p => !p.StartsWith(commandArgs[2])).ToList();
                }
                else if (commandArgs[0] == "Ends")
                {
                    guests = guests.Where(p => !p.EndsWith(commandArgs[2])).ToList();
                }
                else if (commandArgs[0] == "Length")
                {
                    guests = guests.Where(p => p.Length != int.Parse(commandArgs[1])).ToList();
                }
                else if (commandArgs[0] == "Contains")
                {
                    guests = guests.Where(p => !p.Contains(commandArgs[1])).ToList();
                }
            }
                Console.WriteLine(string.Join(" ", guests));
        }
    }
}
