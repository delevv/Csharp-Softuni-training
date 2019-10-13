using System;

namespace DateModifier
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            var dateModifier = new DateModifier();

            double result = dateModifier.GetDifferenceInDaysBetweenTwoDates(firstDate, secondDate);
            Console.WriteLine(result);
        }
    }
}
