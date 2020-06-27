using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace RemoveVillain
{
    public class StartUp
    {
        private const string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;";

        public static void Main(string[] args)
        {
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            var sqlTransaction = sqlConnection.BeginTransaction();

            var villainId = Console.ReadLine();

            try
            {
                //get villain name by Id
                var getVillainByIdQuery = @"SELECT [Name] FROM Villains WHERE Id = @villainId";

                using var getVillainByIdCommand = new SqlCommand(getVillainByIdQuery, sqlConnection);
                getVillainByIdCommand.Parameters.AddWithValue("@villainId", villainId);
                getVillainByIdCommand.Transaction = sqlTransaction;

                var villainName = getVillainByIdCommand.ExecuteScalar()?.ToString();

                var sb = new StringBuilder();

                if (villainName == null)
                {
                    sb.AppendLine("No such villain was found.");
                }
                else
                {
                    //release minions
                    var releaseMinionsQuery = @"DELETE FROM MinionsVillains WHERE VillainId = @villainId";

                    using var releaseMinionsCommand = new SqlCommand(releaseMinionsQuery, sqlConnection);
                    releaseMinionsCommand.Parameters.AddWithValue("@villainId", villainId);
                    releaseMinionsCommand.Transaction = sqlTransaction;

                    var minionsReleased = releaseMinionsCommand.ExecuteNonQuery();

                    //delete villain
                    var deleteVillainQuery = @"DELETE FROM Villains WHERE Id = @villainId";

                    using var deleteVillainCommand = new SqlCommand(deleteVillainQuery, sqlConnection);
                    deleteVillainCommand.Parameters.AddWithValue("@villainId", villainId);
                    deleteVillainCommand.Transaction = sqlTransaction;

                    deleteVillainCommand.ExecuteNonQuery();

                    //add messages
                    sb.AppendLine($"{villainName} was deleted.");
                    sb.AppendLine($"{minionsReleased} minions were released.");
                }

                sqlTransaction.Commit();

                Console.WriteLine(sb.ToString().TrimEnd());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
