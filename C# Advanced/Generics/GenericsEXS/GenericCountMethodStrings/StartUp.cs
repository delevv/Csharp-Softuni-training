using System;

namespace GenericCountMethodStrings
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var counter = double.Parse(Console.ReadLine());

            var box = new Box<double>();

            for (int i = 0; i < counter; i++)
            {
                var input = double.Parse(Console.ReadLine());

                box.Values.Add(input);
            }

            var targetItem = double.Parse(Console.ReadLine());

           int result= box.CountOfGreaterValuesThan(targetItem);

            Console.WriteLine(result);
        }
    }
}
