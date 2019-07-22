using System;
using System.Collections.Generic;
using System.Linq;

namespace EasternShopping
{
    class Program
    {
        static void VisitFirstOrLast(List<string> shops,string firstOrLast,int countOfShops)
        {
            if (countOfShops <= shops.Count)
            {
                if (firstOrLast == "first")
                {
                    shops.RemoveRange(0, countOfShops);
                }
                else if (firstOrLast == "last")
                {
                    for (int i = 0; i < countOfShops; i++)
                    {
                        shops.RemoveAt(shops.Count - 1);
                    }
                }
            }
        }
        static void Prefer(List<string> shops, int index1,int index2)
        {
            if ((index1 >= 0 && index1 < shops.Count) && (index2 >= 0 && index2 < shops.Count))
            {
                string remaind = shops.ElementAt(index1);
                shops[index1] = shops[index2];
                shops[index2] = remaind;
            }
        }
        static void Place(List<string>shops,string shop,int index)
        {
            if(index>=0 && index<shops.Count)
            {
                shops.Insert(index+1, shop);
            }
        }
        static void Main(string[] args)
        {
            List<string> shops = Console.ReadLine().Split().ToList();
            int countOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfCommands; i++)
            {
                string [] command = Console.ReadLine().Split().ToArray();

                if (command[0] == "Include")
                {
                    shops.Add(command[1]);
                }
                else if (command[0] == "Visit")
                {
                    int count = int.Parse(command[2]);
                    VisitFirstOrLast(shops, command[1], count);
                }
                else if (command[0] == "Prefer")
                {
                    Prefer(shops,int.Parse(command[1]), int.Parse(command[2]));
                }
                else if (command[0] == "Place")
                {
                    Place(shops, command[1], int.Parse(command[2]));
                }
            }
            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(" ", shops));
        }
    }
}
