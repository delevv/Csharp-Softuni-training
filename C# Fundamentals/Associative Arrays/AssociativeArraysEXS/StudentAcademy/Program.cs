using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var students = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(student))
                {
                    students[student] = new List<double>();
                }
                students[student].Add(grade);
            }
            students = students.OrderByDescending(x => x.Value.Average()).Where(x=>x.Value.Average()>=4.50).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
            }
        }
    }
}
