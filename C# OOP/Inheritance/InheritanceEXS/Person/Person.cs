using System;
using System.Text;

namespace Person
{
    public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append($"Name: {this.Name}, Age: {this.Age}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
