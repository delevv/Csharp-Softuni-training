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


                 string firstName = info[0];
                 string lastName = info[1];
                int age = int.Parse(info[2]);
                string homeTown = info[3];

                bool isNew = true;
                foreach (var student in students)
                {
                    if(student.FirstName==firstName && student.LastName == lastName)
                    {
                        student.Age = age;
                        student.HomeTown = homeTown;
                        isNew = false;
                    }
                }
                if (isNew)
                {
                    Student newStudent = new Student();

                    newStudent.FirstName = firstName;
                    newStudent.LastName = lastName;
                    newStudent.Age = age;
                    newStudent.HomeTown = homeTown;

                    students.Add(newStudent);
                }
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
