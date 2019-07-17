using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniCoursePlanning
{
    class Program
    {
        static void SwapExercise(List<string> schedule, string exercise, string lesson)
        {
            int indexOfExercise = schedule.IndexOf(exercise);
            string currentExercise = schedule[indexOfExercise];
            schedule.RemoveAt(indexOfExercise);
            int indexOfLesson = schedule.IndexOf(lesson);
            schedule.Insert(indexOfLesson + 1, currentExercise);
        }
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine().Split(", ").ToList();

            string[] command = Console.ReadLine().Split(":").ToArray();

            while (command[0] != "course start")
            {
                string lesson = command[1];
                string exercise = $"{lesson}-Exercise";

                if (command[0] == "Add")
                {
                    if (!schedule.Contains(lesson))
                    {
                        schedule.Add(lesson);
                    }
                }
                else if (command[0] == "Insert")
                {
                    int index = int.Parse(command[2]);
                    if (!schedule.Contains(lesson))
                    {
                        schedule.Insert(index, lesson);
                    }
                }
                else if (command[0] == "Remove")
                {
                    if (schedule.Contains(lesson))
                    {
                        int index = schedule.IndexOf(lesson);
                        schedule.RemoveAt(index);
                    }
                    if (schedule.Contains(exercise))
                    {
                        int index = schedule.IndexOf(exercise);
                        schedule.RemoveAt(index);
                    }
                }
                else if (command[0] == "Swap")
                {
                    string secondLesson = command[2];
                    if(schedule.Contains(lesson) && schedule.Contains(secondLesson))
                    {
                        int firstIndex = schedule.IndexOf(lesson);
                        int secondIndex = schedule.IndexOf(secondLesson);
                  
                        schedule[firstIndex] = secondLesson;
                        schedule[secondIndex] = lesson;

                        if (schedule.Contains(exercise))
                        {
                            SwapExercise(schedule, exercise, lesson);
                        }
                        exercise = $"{secondLesson}-Exercise";

                        if (schedule.Contains(exercise))
                        {
                            SwapExercise(schedule, exercise, secondLesson);
                        }
                    }
                }
                else if (command[0] == "Exercise")
                {
                    if (schedule.Contains(lesson))
                    {
                        if (!schedule.Contains(exercise))
                        {
                            int index = schedule.IndexOf(lesson);
                            schedule.Insert(index + 1, exercise);
                        }
                    }
                    else
                    {
                        schedule.Add(lesson);
                        schedule.Add(exercise);
                    }
                }
                command = Console.ReadLine().Split(":").ToArray();
            }
            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{schedule[i]}");
            }
        }
    }
}
