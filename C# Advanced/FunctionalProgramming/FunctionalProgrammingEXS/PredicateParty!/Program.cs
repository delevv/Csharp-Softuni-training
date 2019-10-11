using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty_
{
    class Program
    {
        static List<string> DoubleNames(List<string> peopleList, List<string> peopleToDouble)
        {
            foreach (var person in peopleToDouble.ToList())
            {
                int index = peopleList.IndexOf(person);

                peopleList.Insert(index + 1, person);
            }
            return peopleList;
        }
        static void Main(string[] args)
        {
            var peopleList = Console.ReadLine().Split().ToList();

            Func<string, string, bool> StartsWithFunc = (name, param) => name.StartsWith(param);
            Func<string, string, bool> EndsWithFunc = (name, param) => name.EndsWith(param);
            Func<string, int, bool> LengthFunc = (name, param) => name.Length == param;

            var command = "";

            while ((command = Console.ReadLine()) != "Party!")
            {
                var commandArgs = command.Split();

                var action = commandArgs[0];
                var criteria = commandArgs[1];
                var criteriaParam = commandArgs[2];

                if (action == "Remove")
                {
                    if (criteria == "StartsWith")
                    {
                        peopleList.RemoveAll(x => StartsWithFunc(x, criteriaParam));
                    }
                    else if (criteria == "EndsWith")
                    {
                        peopleList.RemoveAll(x => EndsWithFunc(x, criteriaParam));
                    }
                    else if (criteria == "Length")
                    {
                        var lenght = int.Parse(criteriaParam);
                        peopleList.RemoveAll(x => LengthFunc(x, lenght));
                    }
                }
                else if (action == "Double")
                {
                    if (criteria == "StartsWith")
                    {
                        var peopleToDouble = new List<string>(peopleList);

                        peopleToDouble.RemoveAll(x => !StartsWithFunc(x, criteriaParam));

                        peopleList = DoubleNames(peopleList, peopleToDouble);
                    }
                    else if (criteria == "EndsWith")
                    {
                        var peopleToDouble = new List<string>(peopleList);

                        peopleToDouble.RemoveAll(x => !EndsWithFunc(x, criteriaParam));

                        peopleList = DoubleNames(peopleList, peopleToDouble);
                    }
                    else if (criteria == "Length")
                    {
                        var lenght = int.Parse(criteriaParam);

                        var peopleToDouble = new List<string>(peopleList);

                        peopleToDouble.RemoveAll(x => !LengthFunc(x, lenght));

                        peopleList = DoubleNames(peopleList, peopleToDouble);
                    }
                }
            }
            if (peopleList.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ",peopleList)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
