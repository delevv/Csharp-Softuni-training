using System;

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var list = new RandomList() { "1", "2", "3" };

            Console.WriteLine(list.RandomString());
        }
    }
}
