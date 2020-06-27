using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintAllMinionNames
{
    public class StartUp
    {
        private const string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=true;";

        public static void Main(string[] args)
        {
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            var getMinionsNamesQuery = @"SELECT [Name] FROM Minions";

            using var getMinionsNamesCommand = new SqlCommand(getMinionsNamesQuery, sqlConnection);

            using var reader = getMinionsNamesCommand.ExecuteReader();

            var names = new List<string>();

            //read minion names from db
            while (reader.Read())
            {
                names.Add(reader[0].ToString());
            }

            var sb = new StringBuilder();

            //add pair names in correct order when names count % 2 == 0
            for (int i = 0; i < names.Count / 2; i++)
            {
                sb.AppendLine(names[i]);
                sb.AppendLine(names[names.Count - i - 1]);   
            }

            //add single name without pair when count % 2 == 1
            if (names.Count % 2 != 0)
            {
                sb.AppendLine(names[names.Count / 2]);
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
