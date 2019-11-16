namespace BorderControl
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var currentCreatures = new List<IId>();

            var command = "";

            while ((command = Console.ReadLine()) != "End")
            {
                var info = command.Split();

                IId creature = null;

                if (info.Length == 5)
                {
                    var name = info[1];
                    var age = int.Parse(info[2]);
                    var id = info[3];
                    var birthdate = info[4];

                    creature = new Citizen(name, age, id,birthdate);
                }
                else
                {
                    if (info[0] == "Pet")
                    {
                        var name = info[1];
                        var birthdate = info[2];

                        creature = new Pet(name,birthdate);
                    }
                }
                if (creature != null)
                {
                
                    currentCreatures.Add(creature);
                }
            }

            var criteria = Console.ReadLine();

            foreach (var creature in currentCreatures)
            {
                if (creature.Birthdate.EndsWith(criteria))
                {
                    Console.WriteLine(creature.Birthdate);
                }
            }
        }
    }
}
