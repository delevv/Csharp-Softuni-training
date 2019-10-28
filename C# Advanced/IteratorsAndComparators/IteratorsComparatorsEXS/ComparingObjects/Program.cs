using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class Program
    {
       public  static void Main(string[] args)
        {
            var people = new List<Person>();

            var command = "";

            while ((command = Console.ReadLine()) != "END")
            {
                var personInfo = command.Split();

                var name = personInfo[0];
                var age = int.Parse(personInfo[1]);
                var town = personInfo[2];

                people.Add(new Person(name, age, town));
            }

            var personNumber = int.Parse(Console.ReadLine());

            var targetPerson = people[personNumber - 1];
            var matches = 1;

            foreach (var person in people)
            {
                if (person.CompareTo(targetPerson) == 0 && !person.Equals(targetPerson))
                {
                    matches++;
                }
            }

            if (matches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {people.Count-matches} {people.Count}");
            }
        }
    }
}
