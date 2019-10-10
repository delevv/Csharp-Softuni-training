using System;
using System.Linq;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> CustomComparer = (a, b) =>
              {
                  if(a%2==0 && b % 2 == 0)
                  {
                      if (a < b)
                      {
                          return -1;
                      }
                      else if (a > b)
                      {
                          return 1;
                      }
                      return 0;
                  }
                  if (a % 2 != 0 && b % 2 != 0)
                  {
                      if (a < b)
                      {
                          return -1;
                      }
                      else if (a > b)
                      {
                          return 1;
                      }
                      return 0;
                  }
                  if (a % 2 == 0)
                  {
                      return -1;
                  }
                  if (b % 2 == 0)
                  {
                      return 1;
                  }
                  return 0;
              };

            Array.Sort(numbers, new Comparison<int>(CustomComparer));

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
