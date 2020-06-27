using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Text;

namespace IncreaseMinionAge
{
    public class StartUp
    {
        private const string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;";

        public static void Main(string[] args)
        {
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            var minionsId = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            //update minions with given ids
            var updateMinionsQuery = @$"UPDATE Minions
                                       SET [Name] = UPPER(LEFT(Name, 1)) + LOWER(RIGHT(Name, LEN(Name)-1)),
                                           Age += 1
                                       WHERE Id IN({string.Join(", ", minionsId)})";

            using var updateMinionsCommand = new SqlCommand(updateMinionsQuery, sqlConnection);
            updateMinionsCommand.ExecuteNonQuery();

            //print all minions in format "<Name> <Age>"
            var getMinionsQuery = @"SELECT [Name], Age FROM Minions";

            using var getMinionsCommand = new SqlCommand(getMinionsQuery, sqlConnection);
            
            using var reader = getMinionsCommand.ExecuteReader();

            var sb = new StringBuilder();

            while (reader.Read())
            {
                sb.AppendLine($"{reader[0]?.ToString()} {reader[1]?.ToString()}");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
