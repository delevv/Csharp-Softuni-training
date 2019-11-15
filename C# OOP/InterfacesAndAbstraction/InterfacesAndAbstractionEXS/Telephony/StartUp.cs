namespace Telephony
{
    using System;
    
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            var sites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var smartphone = new Smartphone();

            foreach (var number in phoneNumbers)
            {
                Console.WriteLine(smartphone.Call(number));
            }

            foreach (var site in sites)
            {
                Console.WriteLine(smartphone.Browse(site));
            }
        }
    }
}
