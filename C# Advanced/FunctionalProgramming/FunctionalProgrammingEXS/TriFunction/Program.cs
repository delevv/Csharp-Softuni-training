using System;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> isEqualOrLargerFunc = (word, param) => word.Sum(x => x) >= param;

            var targetSum = int.Parse(Console.ReadLine());

            var names = Console.ReadLine().Split();

            Func<string[], Func<string, int, bool>,int, string> filterFunc = (peopleNames, isLargerFunc,neededSum) =>
            {
                return peopleNames.FirstOrDefault(x => isLargerFunc(x, neededSum));
            };

            var resultName = filterFunc(names, isEqualOrLargerFunc,targetSum);

            Console.WriteLine(resultName);
        }
    }
}
