using System;
using System.Collections.Generic;
using System.Linq;
namespace Students
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public Student(string first,string second,double grade)
        {
            this.FirstName = first;
            this.LastName = second;
            this.Grade = grade;
        }
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}: {this.Grade:f2}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < count; i++)
            {
                string[] info = Console.ReadLine().Split();

                Student student = new Student(info[0], info[1], double.Parse(info[2]));

                students.Add(student);
            }

            students = students.OrderByDescending(x => x.Grade).ToList();

            students.ForEach(x => Console.WriteLine(x));
        }
    }
}
