using System;
using System.Collections.Generic;
using System.Linq;

namespace Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, Dictionary<string, int>>();
            var students = new Dictionary<string, int>();

            string command;

            while ((command = Console.ReadLine()) != "no more time")
            {
                string[] info = command.Split(" -> ");
                string name = info[0];
                string contest = info[1];
                int points = int.Parse(info[2]);

                if (!contests.ContainsKey(contest))
                {
                    contests[contest] = new Dictionary<string, int>();
                }
                if (contests[contest].ContainsKey(name))
                {
                    if (contests[contest][name] < points)
                    {
                        contests[contest][name] = points;
                        students[name] = points;
                    }
                }
                else
                {
                    contests[contest][name] = points;
                    if (!students.ContainsKey(name))
                    {
                        students[name] = 0;
                    }
                    students[name] += points;
                }
            }

            foreach (var contest in contests)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count()} participants");

                var currentContest = contest.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                int studentPosition = 1;
                foreach (var student in currentContest)
                {
                    Console.WriteLine($"{studentPosition}. {student.Key} <::> {student.Value}");
                    studentPosition++;
                }
            }
            Console.WriteLine("Individual standings: ");

            students=students.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            int position = 1;
            foreach (var student in students)
            {
                Console.WriteLine($"{position}. {student.Key} -> {student.Value}");
                position++;
            }
        }
    }
}
