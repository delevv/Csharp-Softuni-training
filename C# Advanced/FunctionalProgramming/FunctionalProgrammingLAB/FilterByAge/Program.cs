using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var countOfPersons = int.Parse(Console.ReadLine());

            var persons = new List<Person>();

            for (int i = 0; i < countOfPersons; i++)
            {
                var currentPersonInfo = Console.ReadLine().Split(", ");

                var currentPerson = new Person();

                currentPerson.Name = currentPersonInfo[0];
                currentPerson.Age = int.Parse(currentPersonInfo[1]);

                persons.Add(currentPerson);
            }
            var conditionType = Console.ReadLine();
            var conditionNumber = int.Parse(Console.ReadLine());

            Func<Person, bool> condition;

            if (conditionType == "older")
            {
                condition = p => p.Age >= conditionNumber;
            }
            else
            {
                condition = p => p.Age <= conditionNumber;
            }

            var personsAfterFilter = persons.Where(condition);

            var format = Console.ReadLine();

            foreach (var person in personsAfterFilter)
            {
                switch (format)
                {
                    case "name age":
                        Console.WriteLine($"{person.Name} - {person.Age}");
                        break;
                    case "name":
                        Console.WriteLine($"{person.Name}");
                        break;
                    case "age":
                        Console.WriteLine($"{person.Age}");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
