using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfDragons = int.Parse(Console.ReadLine());
            var typesAndDragons = new Dictionary<string, SortedDictionary<string, Dragon>>();

            for (int i = 0; i < countOfDragons; i++)
            {
                string[] info = Console.ReadLine().Split();
                string type = info[0];
                string name = info[1];
                int demage = info[2]=="null" ? 45 : int.Parse(info[2]);
                int health= info[3]== "null" ? 250 : int.Parse(info[3]);
                int armor = info[4]== "null" ? 10 : int.Parse(info[4]);
        
                if(!typesAndDragons.ContainsKey(type))
                {
                    typesAndDragons[type] = new SortedDictionary<string, Dragon>();
                }
                if (!typesAndDragons[type].ContainsKey(name))
                {
                    typesAndDragons[type][name] = new Dragon();
                }
                typesAndDragons[type][name].Demage = demage;
                typesAndDragons[type][name].Health = health;
                typesAndDragons[type][name].Armor = armor;
            }
            foreach (var type in typesAndDragons)
            {
                int totalDemage = 0;
                int totalHealth = 0;
                int totalArmor = 0;

                foreach (var dragon in type.Value)
                {
                    totalDemage += dragon.Value.Demage;
                    totalHealth += dragon.Value.Health;
                    totalArmor += dragon.Value.Armor;
                }
                Console.WriteLine($"{type.Key}::({totalDemage*1.00/type.Value.Values.Count():f2}/{totalHealth*1.00 / type.Value.Values.Count():f2}/{totalArmor*1.00 / type.Value.Values.Count():f2})");

                foreach (var dragon  in type.Value)
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value.Demage}, health: {dragon.Value.Health}, armor: {dragon.Value.Armor}");
                }
            }
        }
    }
    class Dragon
    {
        public int Demage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
    }
}
