using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var courses = new Dictionary<string, List<string>>();

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] info = command.Split(" : ");
                string courseName = info[0];
                string studentName = info[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses[courseName] = new List<string>();
                }
                courses[courseName].Add(studentName);
            }

            courses = courses.OrderByDescending(x => x.Value.Count).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                course.Value.OrderBy(x => x).ToList().ForEach(x => Console.WriteLine($"-- {x}"));
            }
        }
    }
}
