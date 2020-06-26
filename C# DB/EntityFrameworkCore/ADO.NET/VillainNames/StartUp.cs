using System;
using Microsoft.Data.SqlClient;

namespace VillainNames
{
    public class StartUp
    {
        private const string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;";

        public static void Main(string[] args)
        {
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            var getVillainsQuery = @"SELECT v.[Name],
                                            COUNT(*) AS MinionsCount
                                     FROM Villains AS v
                                     LEFT JOIN MinionsVillains AS mv ON mv.VillainId = v.Id
                                     GROUP BY v.[Name]
                                     HAVING COUNT(*) >= 3
                                     ORDER BY MinionsCount DESC";

            using var sqlCommand = new SqlCommand(getVillainsQuery, sqlConnection);

            using var reader = sqlCommand.ExecuteReader();
            
            while (reader.Read())
            {
                Console.WriteLine(reader.ToString());
                Console.WriteLine($"{reader[0]} - {reader[1]}");
            }
        }
    }
}
