using System;
using System.Linq;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var counter = int.Parse(Console.ReadLine());

            var box = new Box<string>();

            for (int i = 0; i < counter; i++)
            {
                var input = Console.ReadLine();

                box.Values.Add(input);
            }

            var swapIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var firstIndex = swapIndexes[0];
            var secondIndex = swapIndexes[1];

            box.Swap(firstIndex, secondIndex);

            Console.WriteLine(box);
        }
    }
}
