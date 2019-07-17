using System;
using System.Linq;
using System.Collections.Generic;

namespace EasterGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> gifts = Console.ReadLine().Split().ToList();

            string command;

            while((command=Console.ReadLine())!="No Money")
            {
                string[] array = command.Split().ToArray();

                if (array[0] == "OutOfStock")
                {
                    string gift = array[1];
                    while (gifts.Contains(gift))
                    {

                        int index = gifts.IndexOf(gift);
                        gifts[index] = "None";
                    }
                }
                else if (array[0] == "Required")
                {
                    string gift = array[1];
                    int index = int.Parse(array[2]);
                    if(index>=0 && index < gifts.Count)
                    {
                        gifts[index] = gift;
                    }
                }
                else if (array[0] == "JustInCase")
                {
                    string gift = array[1];
                    gifts[gifts.Count - 1] = gift;
                }
            }
            for (int i = 0; i < gifts.Count; i++)
            {
                if (gifts[i] != "None")
                {
                    Console.Write(gifts[i] + " ");
                }
            }
        }
    }
}
