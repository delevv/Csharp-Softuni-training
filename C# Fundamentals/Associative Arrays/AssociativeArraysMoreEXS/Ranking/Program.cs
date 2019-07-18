using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contestAndPassword = new Dictionary<string, string>();

            string command;

            while((command=Console.ReadLine())!="end of contests")
            {
                string[] info = command.Split(":");

                contestAndPassword[info[0]] = info[1];
            }

            var students = new Dictionary<string,Dictionary<string, int>>();

            while ((command = Console.ReadLine()) != "end of submissions")
            {
                string[] info = command.Split("=>");
                string contest = info[0];
                string password = info[1];
                string name = info[2];
                int points = int.Parse(info[3]);

                if (contestAndPassword.ContainsKey(contest))
                {
                    if (contestAndPassword[contest] == password)
                    {
                        if (!students.ContainsKey(name))
                        {
                            students[name] = new Dictionary<string, int>();
                            students[name][contest]=points;
                        }
                        else
                        {
                            if (students[name].ContainsKey(contest))
                            {
                                if (students[name][contest] < points)
                                {
                                    students[name][contest] = points;
                                }
                            }
                            else
                            {
                                students[name][contest] = points;
                            }
                        }
                    }
                }
            }
            string bestName = "";
            int bestPoints = 0;
            foreach (var student in students)
            {
                string name = student.Key;
                int points = 0;
                foreach (var contest in student.Value)
                {
                    points += contest.Value;
                }
                if (points > bestPoints)
                {
                    bestName = name;
                    bestPoints = points;
                }
            }
            Console.WriteLine($"Best candidate is {bestName} with total {bestPoints} points.");
            Console.WriteLine("Ranking: ");

            students = students.OrderBy(x => x.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var student in students)
            {
                Console.WriteLine(student.Key);

                var currentContest = student.Value.OrderByDescending(x => x.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                foreach (var contest in currentContest)
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
