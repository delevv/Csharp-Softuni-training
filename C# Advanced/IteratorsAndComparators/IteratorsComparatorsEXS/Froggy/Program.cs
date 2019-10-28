using System;
using System.Linq;

namespace Froggy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToList();

            var lake = new Lake(numbers);

            Console.WriteLine(string.Join(", ",lake));
        }
    }
}
