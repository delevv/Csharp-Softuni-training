using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderByAge
{
    class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{this.Name} with ID: {this.Id} is {this.Age} years old.";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] info = command.Split();

                Person person = new Person();
                person.Name = info[0];
                person.Id = info[1];
                person.Age = int.Parse(info[2]);
                persons.Add(person);

            }
            persons=persons.OrderBy(x => x.Age).ToList();

            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}
