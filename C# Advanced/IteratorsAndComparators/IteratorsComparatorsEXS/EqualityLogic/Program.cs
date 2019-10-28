using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class Program
    {
       public  static void Main(string[] args)
        {
            var people = new HashSet<Person>();
            var sortedPeople = new SortedSet<Person>();

            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var personInfo = Console.ReadLine().Split();

                var name = personInfo[0];
                var age = int.Parse(personInfo[1]);

                var person = new Person(name, age);

                people.Add(person);
                sortedPeople.Add(person);
            }

            Console.WriteLine(people.Count);
            Console.WriteLine(sortedPeople.Count);
        }
    }
}
