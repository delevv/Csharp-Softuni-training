using System;
using System.Linq;

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
            var inputBankInfo = Console.ReadLine()
                .Split();

            var fullName = inputPersonInfo[0] + " " + inputPersonInfo[1];
            var address = inputPersonInfo[2];
            var town = string.Join(" ",inputPersonInfo.Skip(3));

            var name = inputPersonBeer[0];
            var liters = int.Parse(inputPersonBeer[1]);
            var drunkOrNot = inputPersonBeer[2];
            var isDrunk = drunkOrNot == "drunk" ? true : false;

            var personName = inputBankInfo[0];
            var balance = double.Parse(inputBankInfo[1]);
            var bankName = inputBankInfo[2];

            var personInfo = new Threeuple<string, string,string>(fullName, address,town);
            var personBeer = new Threeuple<string, int,bool>(name, liters,isDrunk);
            var bankInfo = new Threeuple<string,double,string>(personName, balance,bankName);

            Console.WriteLine(personInfo);
            Console.WriteLine(personBeer);
            Console.WriteLine(bankInfo);
        }
    }
}
