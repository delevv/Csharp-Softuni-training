using System;
using System.Collections.Generic;
using System.Linq;

namespace OldestFamilyMember
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Family
    {
        public List<Person> PeopleList { get; set; }

        public Family()
        {
            this.PeopleList = new List<Person>();
        }
        public void Add(Person member)
        {
            this.PeopleList.Add(member);
        }
        public Person GetOldest()
        {
            return this.PeopleList.OrderByDescending(p => p.Age).First();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < count; i++)
            {
                string[] info = Console.ReadLine().Split();
                Person person = new Person();
                person.Name = info[0];
                person.Age = int.Parse(info[1]);

                family.Add(person);
            }
            Person oldest = family.GetOldest();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}
