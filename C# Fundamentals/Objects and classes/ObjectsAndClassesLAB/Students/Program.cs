using System;
using System.Collections.Generic;

namespace Students
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] info = command.Split();

                Student newStudent = new Student();

                newStudent.FirstName = info[0];
                newStudent.LastName = info[1];
                newStudent.Age = int.Parse(info[2]);
                newStudent.HomeTown = info[3];

                students.Add(newStudent);
            }

            string town = Console.ReadLine();

            foreach (var student in students)
            {
                if (student.HomeTown == town)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }
}
