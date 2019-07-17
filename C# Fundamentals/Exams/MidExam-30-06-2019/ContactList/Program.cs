using System;
using System.Collections.Generic;
using System.Linq;

namespace Exs3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> contacts = Console.ReadLine().Split().ToList();
            
            while (true)
            {
                string[] arr = Console.ReadLine().Split();

                if (arr[0] == "Add")
                {
                    string contact = arr[1];
                    int index = int.Parse(arr[2]);

                    if (!contacts.Contains(contact))
                    {
                        contacts.Add(contact);
                    }
                    else
                    {
                        if(index>=0 && index < contacts.Count)
                        {
                            contacts.Insert(index, contact);
                        }
                    }
                }
                else if (arr[0] == "Remove")
                {
                    int index = int.Parse(arr[1]);

                    if(index>=0 && index< contacts.Count)
                    {
                        contacts.RemoveAt(index);
                    }
                }
                else if (arr[0] == "Export")
                {
                    int startIndex = int.Parse(arr[1]);
                    int count = int.Parse(arr[2]);

                    while (startIndex < contacts.Count && count>0)
                    {
                        Console.Write(contacts[startIndex]+ " ");
                        startIndex++;
                        count--;
                    }
                    Console.WriteLine();
                }
                else if (arr[0] == "Print")
                {
                    string normalOrReversed = arr[1];
                    
                    if (normalOrReversed == "Reversed")
                    {
                        contacts.Reverse();
                    }
                    Console.WriteLine($"Contacts: {string.Join(" ", contacts)}");
                    break;
                }
            }
        }
    }
}
