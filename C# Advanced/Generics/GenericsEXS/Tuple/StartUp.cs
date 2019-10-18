using System;

namespace Tuple
{
   public class StartUp
    {
        public static void Main(string[] args)
        {
            var inputPersonInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var inputPersonBeer = Console.ReadLine()
                .Split();
            var inputNumbersInfo = Console.ReadLine()
                .Split();

            var fullName = inputPersonInfo[0] + " " + inputPersonInfo[1];
            var address = inputPersonInfo[2];

            var name = inputPersonBeer[0];
            var liters = int.Parse(inputPersonBeer[1]);

            var myInt = int.Parse(inputNumbersInfo[0]);
            var myDouble = double.Parse(inputNumbersInfo[1]);

            var personInfo = new MyTuple<string, string>(fullName, address);
            var personBeer = new MyTuple<string, int>(name, liters);
            var numbersInfo = new MyTuple<int, double>(myInt, myDouble);

            Console.WriteLine(personInfo);
            Console.WriteLine(personBeer);
            Console.WriteLine(numbersInfo);
        }
    }
}
