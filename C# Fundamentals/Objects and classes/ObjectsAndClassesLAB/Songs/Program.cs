using System;
using System.Collections.Generic;

namespace Songs
{
    class Song
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();

            for (int i = 0; i < count; i++)
            {
                string[] data = Console.ReadLine().Split("_");

                Song song = new Song();

                song.Type = data[0];
                song.Name = data[1];
                song.Time = data[2];

                songs.Add(song);
            }
            string typeList = Console.ReadLine();

            if (typeList == "all")
            {
                foreach (var item in songs)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                foreach (var item in songs)
                {
                    if (item.Type == typeList)
                    {
                        Console.WriteLine(item.Name);
                    }
                }
            }
            
        }
    }
}
