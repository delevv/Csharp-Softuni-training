using System;

namespace GenericScale
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var equal = new EqualityScale<string>("Gosho", "Gosho");

            Console.WriteLine(equal.AreEqual());
        }
    }
}
