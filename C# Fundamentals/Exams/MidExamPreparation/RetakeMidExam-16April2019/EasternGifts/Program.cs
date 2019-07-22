using System;
using System.Linq;
namespace EasternGifts
{
    class Program
    {
        static void OutOfStock(string[] gifts,string gift)
        {
            for (int i = 0; i < gifts.Length; i++)
            {
                if (gifts[i] == gift)
                {
                    gifts[i] = "None";
                }
            }
        }
        static void Required(string[]array,string gift,int index)
        {
            if (index >=0 && index < array.Length)
            {
                array[index] = gift;
            }
        }
        static void JustInCase(string [] array,string gift)
        {
            array[array.Length - 1] = gift;
        }
        static void Main(string[] args)
        {
            string[] gifts = Console.ReadLine().Split().ToArray();
            string command = Console.ReadLine();
            
            while(command!="No Money")
            {
                string[] commandToArray = command.Split().ToArray();
                if (commandToArray[0] == "OutOfStock")
                {
                    OutOfStock(gifts,commandToArray[1]);
                }
                else if(commandToArray[0] == "Required")
                {
                    int index = int.Parse(commandToArray[2]);
                    Required(gifts, commandToArray[1], index);
                }
                else if (commandToArray[0] == "JustInCase")
                {
                    JustInCase(gifts, commandToArray[1]);
                }
                command = Console.ReadLine();
            }
            for (int i = 0; i < gifts.Length; i++)
            {
                if (gifts[i] != "None")
                {
                    Console.Write(gifts[i] + " ");
                }
            }
        }
    }
}
