namespace Ferrari
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var driverName = Console.ReadLine();

            var ferrari = new Ferrari(driverName);

            Console.WriteLine(ferrari);
        }
    }
}
