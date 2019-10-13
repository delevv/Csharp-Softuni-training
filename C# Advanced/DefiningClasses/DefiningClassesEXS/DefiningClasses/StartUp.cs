using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var countOfPeople = int.Parse(Console.ReadLine());
            var family = new Family();

            for (int i = 0; i < countOfPeople; i++)
            {
                var personInfo = Console.ReadLine().Split();

                var personName = personInfo[0];
                var personAge = int.Parse(personInfo[1]);

                var person = new Person(personName, personAge);
                family.AddMember(person);
            }
       
            family.PeopleList
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToList()
                .ForEach(p => Console.WriteLine($"{p.Name} - {p.Age}"));
        }   
    }
}
