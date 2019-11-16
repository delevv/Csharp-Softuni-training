namespace BorderControl
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            var currentCreatures = new List<IId>();

            var command = "";

            while ((command = Console.ReadLine()) != "End")
            {
                var info = command.Split();

                IId creature = null;

                if (info.Length == 3)
                {
                    var name = info[0];
                    var age = int.Parse(info[1]);
                    var id = info[2];

                    creature = new Citizen(name, age, id);
                }
                else
                {
                    var model = info[0];
                    var id = info[1];

                    creature = new Robot(model, id);
                }

                currentCreatures.Add(creature);
            }

            var criteria = Console.ReadLine();

            foreach (var creature in currentCreatures)
            {
                if (creature.Id.EndsWith(criteria))
                {
                    Console.WriteLine(creature.Id);
                }
            }
        }
    }
}
