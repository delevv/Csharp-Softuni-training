using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person();

            var name = "Pesho";
            var age = 20;

            person.Name = name;
            person.Age = age;
        }   
    }
}
