using Microsoft.Data.SqlClient;
using System;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace MinionNames
{
    public class StartUp
    {
        private const string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;";

        public static void Main(string[] args)
        {
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            Console.WriteLine("Enter Villain Id:");
            var villainId = int.Parse(Console.ReadLine());

            var result = GetMinionInfoAboutVillain(sqlConnection, villainId);

            Console.WriteLine(result);
        }

        public static string GetMinionInfoAboutVillain(SqlConnection sqlConnection, int villainId)
        {
            var villainName = GetVillainNameById(sqlConnection, villainId);

            var sb = new StringBuilder();

            if (villainName == null)
            {
                sb.AppendLine($"No villain with ID {villainId} exists in the database.");
            }
            else
            {
                sb.AppendLine($"Villain: {villainName}");

                var getMinionsInfoQuery = @"SELECT m.[Name],
                                                   m.Age
                                            FROM Villains AS v
                                            LEFT JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                                            LEFT JOIN Minions AS m ON mv.MinionId = m.Id
                                            WHERE v.[Name] = @villainName
                                            ORDER BY m.[Name]";

                using var getMinionsCommand = new SqlCommand(getMinionsInfoQuery, sqlConnection);
                getMinionsCommand.Parameters.AddWithValue("@villainName", villainName);

                using var reader = getMinionsCommand.ExecuteReader();

                var counter = 1;

                while (reader.Read())
                {
                    var name = reader[0]?.ToString();
                    var age = reader[1]?.ToString();

                    if (name == "" && age == "")
                    {
                        sb.AppendLine("(no minions)");
                        break;
                    }

                    sb.AppendLine($"{counter++}. {name} {age}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetVillainNameById(SqlConnection sqlConnection, int villainId)
        {
            var getVillainNameByIdQuery = @"SELECT [Name] 
                                            FROM Villains
                                            WHERE Id = @villainId";

            using var getNameCommand = new SqlCommand(getVillainNameByIdQuery, sqlConnection);
            getNameCommand.Parameters.AddWithValue("@villainId", villainId);

            return getNameCommand.ExecuteScalar()?.ToString();
        }
    }
}
