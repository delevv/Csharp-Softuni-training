using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Person person=null;

            if (age>=0 && age <= 15)
            {
                person = new Child(name, age);
            }
            else if (age >= 0)
            {
                person = new Person(name,age);
            }
             
            Console.WriteLine(person);
        }
    }
}