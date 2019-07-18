using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftuniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = new Dictionary<string, int>();
            var languages = new Dictionary<string, int>();

            string command;
            while((command=Console.ReadLine())!="exam finished")
            {
                string[] info = command.Split("-");
                if (info[1] != "banned")
                {
                    string name = info[0];
                    string language = info[1];
                    int points = int.Parse(info[2]);

                    if (!students.ContainsKey(name))
                    {
                        students[name] = 0;
                    }
                    if (points > students[name])
                    {
                        students[name] = points;
                    }
                    if (!languages.ContainsKey(language))
                    {
                        languages[language] = 0;
                    }
                    languages[language]++;
                }
                else
                {
                    string name = info[0];
                    students.Remove(name);
                }
            }
            Console.WriteLine("Results:");

            students = students.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} | {student.Value}");
            }

            languages=languages.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine("Submissions:");

            foreach (var language in languages)
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
