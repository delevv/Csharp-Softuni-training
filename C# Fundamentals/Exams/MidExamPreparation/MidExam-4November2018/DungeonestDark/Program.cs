using System;

namespace DungeonestDark
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine().Split("|");
            int health = 100;
            int coins = 0;

            for (int i = 0; i < rooms.Length; i++)
            {
                string[] currentRoom = rooms[i].Split();

                if (currentRoom[0] == "potion")
                {
                    int heal = int.Parse(currentRoom[1]);
                    if (health + heal > 100)
                    {
                        heal = 100 - health;
                    }
                    health += heal;
                    Console.WriteLine($"You healed for {heal} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (currentRoom[0] == "chest")
                {
                    coins += int.Parse(currentRoom[1]);
                    Console.WriteLine($"You found {int.Parse(currentRoom[1])} coins.");
                }
                else
                {
                    string monster = currentRoom[0];
                    int attack = int.Parse(currentRoom[1]);

                    if (health - attack > 0)
                    {
                        Console.WriteLine($"You slayed {monster}.");
                        health -= attack;
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                        Console.WriteLine($"Best room: {i+1}");
                        break;
                    }

                }
                if (i == rooms.Length - 1)
                {
                    Console.WriteLine($"You've made it!");
                    Console.WriteLine($"Coins: {coins}");
                    Console.WriteLine($"Health: {health}");                 
                }
            }

        }
    }
}
