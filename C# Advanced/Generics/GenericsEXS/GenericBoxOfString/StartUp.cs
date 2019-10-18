using System;

namespace GenericBoxOfString
{
    public class StartUp
    {
       public static void Main(string[] args)
        {
            var counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                var input = int.Parse(Console.ReadLine());

                var box = new Box<int>(input);

                Console.WriteLine(box);
            }  
        }
    }
}
