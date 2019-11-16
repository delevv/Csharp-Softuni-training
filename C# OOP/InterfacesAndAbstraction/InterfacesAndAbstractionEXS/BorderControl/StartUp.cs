namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var people = new List<IBuyer>();

            var countOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfPeople; i++)
            {
                var currentPersonInfo = Console.ReadLine().Split();

                var name = currentPersonInfo[0];
                var age = int.Parse(currentPersonInfo[1]);

                if (currentPersonInfo.Length == 4)
                {
                    var id = currentPersonInfo[2];
                    var birthdate = currentPersonInfo[3];

                    var citizen = new Citizen(name, age, id, birthdate);

                    people.Add(citizen);
                }
                else
                {
                    var group = currentPersonInfo[2];

                    var rebel = new Rebel(name, age, group);

                    people.Add(rebel);
                }
            }

            var command = "";

            while ((command = Console.ReadLine()) != "End")
            {
                var currentName = command;

                var currentPerson = people.FirstOrDefault(p => p.Name == currentName);

                if (currentPerson != null)
                {
                    currentPerson.BuyFood();
                }
            }

            var totalFoodAmount = people.Sum(p => p.Food);

            Console.WriteLine(totalFoodAmount);
        }
    }
}
