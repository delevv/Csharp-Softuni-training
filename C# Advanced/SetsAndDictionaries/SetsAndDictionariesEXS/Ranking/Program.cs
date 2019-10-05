using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contestsAndPasswords = new Dictionary<string, string>();

            var command = "";

            while((command=Console.ReadLine())!="end of contests")
            {
                var contestInfo = command.Split(":");
                var name = contestInfo[0];
                var password = contestInfo[1];

                if (!contestsAndPasswords.ContainsKey(name))
                {
                    contestsAndPasswords[name] = password;
                }
            }
            var students = new Dictionary<string, Dictionary<string, int>>();

            while ((command = Console.ReadLine()) != "end of submissions")
            {
                var info = command.Split("=>");

                var contestName = info[0];
                var contestPassword = info[1];
                var studentName = info[2];
                var points = int.Parse(info[3]);

                if (contestsAndPasswords.ContainsKey(contestName))
                {
                    if (contestsAndPasswords[contestName] == contestPassword)
                    {
                        if (!students.ContainsKey(studentName))
                        {
                            students[studentName] = new Dictionary<string, int>();
                        }
                        if (!students[studentName].ContainsKey(contestName))
                        {
                            students[studentName][contestName] = points;
                        }
                        else
                        {
                            if (students[studentName][contestName] < points)
                            {
                                students[studentName][contestName] = points;
                            }
                        }
                    }
                }
            }
            var bestCandidate = students
                .OrderByDescending(x => x.Value.Values.Sum())
                .FirstOrDefault();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Values.Sum()} points.");
            Console.WriteLine("Ranking:");

            foreach (var student in students.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{student.Key}");

                foreach (var contests in student.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {contests.Key} -> {contests.Value}");
                }
            }
        }
    }
}
