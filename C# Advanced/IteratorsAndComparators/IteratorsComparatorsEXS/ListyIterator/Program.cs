using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var command = "";

            var elements = Console.ReadLine()
                .Split()
                .Skip(1)
                .ToList();

            var listyIterator = new ListyIterator<string>(elements);


            while ((command = Console.ReadLine()) != "END")
            {


                if (command == "Print")
                {
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);                     
                    }
                }
                else if (command == "Move")
                {
                    Console.WriteLine(listyIterator.Move());
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(listyIterator.HasNext());
                }

            }
        }
    }
}
