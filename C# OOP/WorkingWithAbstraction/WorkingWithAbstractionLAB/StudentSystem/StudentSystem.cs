using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem
{
    public class StudentSystem
    {
        private Dictionary<string, Student> Repository { get; }

        public StudentSystem()
        {
            this.Repository = new Dictionary<string, Student>();
        }

        public void ParseCommand()
        {
            string[] args = Console.ReadLine().Split();

            var command = args[0];

            if (command == "Create")
            {
                var name = args[1];
                var age = int.Parse(args[2]);
                var grade = double.Parse(args[3]);

                this.Create(name,age,grade);
            }
            else if (command == "Show")
            {
                var name = args[1];
                this.Show(name);
            }
            else if (command == "Exit")
            {
                Environment.Exit(0);
            }
        }
        public void Create(string name,int age,double grade)
        {     
            if (!Repository.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                Repository[name] = student;
            }
        }

        public void Show(string name)
        {    
            if (Repository.ContainsKey(name))
            {
                var student = Repository[name];

                Console.WriteLine(student);
            }
        }
    }
}
