using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentsCount = int.Parse(Console.ReadLine());
               
            var students = new Dictionary<string, List<double>>();

            for (int i = 0; i < studentsCount; i++)
            {
                var studentInfo = Console.ReadLine().Split();

                var name = studentInfo[0];
                var grade = double.Parse(studentInfo[1]);

                if (!students.ContainsKey(name))
                {
                    students[name] = new List<double>();
                }
                students[name].Add(grade);
            }
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value.Select(x => x.ToString("F2")))} (avg: {student.Value.Average():f2})");
            }
        }
    }
}
