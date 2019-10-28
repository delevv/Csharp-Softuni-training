using System;
using System.Collections.Generic;
using System.Text;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() +this.Age.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var person = obj as Person;

            if(person.Name==this.Name && person.Age == this.Age)
            {
                return true;
            }

            return false;
        }

        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name) != 0)
            {
                return this.Name.CompareTo(other.Name);
            }

            return this.Age.CompareTo(other.Age);
        }
    }
}
