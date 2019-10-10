using System;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minFunc = numbers =>
            {
                var minNumber = int.MaxValue;

                foreach (var number in numbers)
                {
                    if (number < minNumber)
                    {
                        minNumber = number;
                    }
                }
                return minNumber;
            };

            var inputNumbers= Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(minFunc(inputNumbers)); 
        }
    }
}
