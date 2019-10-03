using System;
using System.Collections.Generic;
using System.Linq;

namespace CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            var countOfOperations = int.Parse(Console.ReadLine());

            var continents = new Dictionary<string,Dictionary<string, List<string>>>();

            for (int i = 0; i < countOfOperations; i++)
            {
                var info = Console.ReadLine().Split();

                var continet = info[0];
                var country = info[1];
                var city = info[2];

                if (!continents.ContainsKey(continet))
                {
                    continents[continet] = new Dictionary<string, List<string>>();
                }
                if (!continents[continet].ContainsKey(country))
                {
                    continents[continet][country] = new List<string>();
                }
                continents[continet][country].Add(city);
            }
            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ",country.Value)}");
                }
            }
        }
    }
}
