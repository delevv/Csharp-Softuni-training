using System;

namespace GenericCountMethodStrings
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var counter = int.Parse(Console.ReadLine());

            var box = new Box<string>();

            for (int i = 0; i < counter; i++)
            {
                string input = Console.ReadLine();

                box.Values.Add(input);
            }

            var targetItem = Console.ReadLine();

           int result= box.CountOfGreaterValuesThan(targetItem);

            Console.WriteLine(result);
        }
    }
}
