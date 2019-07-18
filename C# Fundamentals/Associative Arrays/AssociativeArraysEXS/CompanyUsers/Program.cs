using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            var companies = new Dictionary<string, List<string>>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] info = command.Split(" -> ");

                string companyName = info[0];
                string employeeId = info[1];

                if (!companies.ContainsKey(companyName))
                {
                    companies[companyName] = new List<string>();
                }
                if (!companies[companyName].Contains(employeeId))
                {
                    companies[companyName].Add(employeeId);
                }
            }

            companies = companies.OrderBy(x => x.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var company in companies)
            {
                Console.WriteLine(company.Key);
                company.Value.ForEach(x => Console.WriteLine($"-- {x}"));
            }
        }
    }
}
