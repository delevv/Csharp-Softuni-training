using System;
using System.Collections.Generic;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var songs = Console.ReadLine().Split(", ");

            var queue = new Queue<string>(songs);

            while (true)
            {
                var command = Console.ReadLine();

                if (queue.Count > 0)
                {
                    if (command == "Play")
                    {
                        queue.Dequeue();
                    }
                    else if (command.StartsWith("Add"))
                    {
                        var song = command.Substring(4, command.Length - 4);

                        if (queue.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        else
                        {
                            queue.Enqueue(song); 
                        }
                    }
                    else if (command == "Show")
                    {
                        Console.WriteLine(string.Join(", ", queue));
                    }
                }
                else
                {
                    Console.WriteLine("No more songs!");
                    break;
                }
            }
        }
    }
}
