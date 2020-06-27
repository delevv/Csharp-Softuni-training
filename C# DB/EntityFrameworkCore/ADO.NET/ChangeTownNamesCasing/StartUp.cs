using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeTownNamesCasing
{
    public class StartUp
    {
        private const string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;";

        public static void Main(string[] args)
        {
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            var countryName = Console.ReadLine();

            var updateTownsQuery = @"UPDATE Towns
                                     SET[Name] = UPPER(t.[Name])
                                     FROM Countries AS c
                                     LEFT JOIN Towns AS t ON c.Id = t.CountryCode
                                     WHERE c.[Name] = @countryName";

            using var updateTownsCommand = new SqlCommand(updateTownsQuery, sqlConnection);
            updateTownsCommand.Parameters.AddWithValue("@countryName", countryName);
            
            var rowsAffected = updateTownsCommand.ExecuteNonQuery();

            var sb = new StringBuilder();

            if(rowsAffected > 0)
            {
                var getTownNamesQuery = @"SELECT t.[Name] 
                                          FROM Countries AS c
                                          LEFT JOIN Towns AS t ON c.Id = t.CountryCode
                                          WHERE c.[Name] = @countryName";

                using var getTownNamesCommand = new SqlCommand(getTownNamesQuery, sqlConnection);
                getTownNamesCommand.Parameters.AddWithValue("@countryName", countryName);

                sb.AppendLine($"{rowsAffected} town names were affected.");
           
                using var reader = getTownNamesCommand.ExecuteReader();
                var towns = new List<string>();

                while (reader.Read())
                {
                    towns.Add(reader[0].ToString());
                }

                sb.AppendLine($"[{string.Join(", ", towns)}]");
            }
            else
            {
                sb.AppendLine("No town names were affected.");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
