namespace ExplicitInterfaces
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            var command = "";

            while ((command = Console.ReadLine()) != "End")
            {
                var currentPersonInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var name = currentPersonInfo[0];
                var country = currentPersonInfo[1];
                var age = int.Parse(currentPersonInfo[2]);

                IPerson person = new Citizen(name, country, age);

                Console.WriteLine(person.GetName());
                Console.WriteLine(((IResident)person).GetName());
            }
        }
    }
}
