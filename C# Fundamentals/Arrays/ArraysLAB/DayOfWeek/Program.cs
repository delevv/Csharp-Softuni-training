using System;

namespace DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            int n = int.Parse(Console.ReadLine());

            if (n < 1 || n > 7) Console.WriteLine("Invadlid day!");
            else Console.WriteLine(daysOfWeek[n-1]);
        }   
    }
}
