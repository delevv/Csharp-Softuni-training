using System;
using Microsoft.Data.SqlClient;

namespace IncreasedAgeStoredProcedure
{
    public class StartUp
    {
        private const string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;";

        public static void Main(string[] args)
        {
            var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            //existing minion id
            var minionId = Console.ReadLine();

            //increase minion age using stored procedure
            var increaseAgeQuery = $@"EXEC usp_GetOlder {minionId}";

            using var increaseAgeCommand = new SqlCommand(increaseAgeQuery, sqlConnection);
            increaseAgeCommand.ExecuteNonQuery();

            //print info about minion
            var getMinionQuery = @"SELECT [Name], Age FROM Minions WHERE Id = @minionId";

            using var getMinionCommand = new SqlCommand(getMinionQuery, sqlConnection);
            getMinionCommand.Parameters.AddWithValue("@minionId", minionId);

            using var reader = getMinionCommand.ExecuteReader();
            reader.Read();

            Console.WriteLine($"{reader[0]?.ToString()} - {reader[1]?.ToString()} years old");
        }
    }
}
