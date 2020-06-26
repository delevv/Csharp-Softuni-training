using Microsoft.Data.SqlClient;
using System;

namespace InitialSetup
{
    public class StartUp
    {
        private const string connectionStringMaster = @"Server=.;Database=master;Integrated Security=true;";

        private const string connectionStringMinionsDB = @"Server=.;Database=MinionsDB;Integrated Security=true;";

        public static void Main(string[] args)
        {
            using var sqlConnectionMaster = new SqlConnection(connectionStringMaster);
            sqlConnectionMaster.Open();

            var createMinionsDBQuery = "CREATE DATABASE MinionsDB";
            CreateDatabase(sqlConnectionMaster, createMinionsDBQuery);

            using var sqlConnectionMinionsDB = new SqlConnection(connectionStringMinionsDB);
            sqlConnectionMinionsDB.Open();

            var createTableCountriesQuery = @"CREATE TABLE Countries(
                                            	Id INT PRIMARY KEY IDENTITY,
                                            	[Name] VARCHAR(50) NOT NULL
                                            )";
            CreateTable(sqlConnectionMinionsDB, createTableCountriesQuery);

            var createTableTownsQuery = @"CREATE TABLE Towns(
                                        	Id INT PRIMARY KEY IDENTITY,
                                        	[Name] VARCHAR(50) NOT NULL,
                                        	CountryCode INT NOT NULL REFERENCES Countries(Id)
                                        )";
            CreateTable(sqlConnectionMinionsDB, createTableTownsQuery);

            var createTableMinionsQuery = @"CREATE TABLE Minions(
                                    	Id INT PRIMARY KEY IDENTITY,
                                    	[Name] VARCHAR(50) NOT NULL,
                                    	Age INT NOT NULL,
                                    	TownId INT NOT NULL REFERENCES Towns(Id)
                                    )";
            CreateTable(sqlConnectionMinionsDB, createTableMinionsQuery);

            var createTableEvilnessFactorsQuery = @"CREATE TABLE EvilnessFactors(
                                            	Id INT PRIMARY KEY IDENTITY,
                                            	[Name] VARCHAR(50) NOT NULL
                                            )";
            CreateTable(sqlConnectionMinionsDB, createTableEvilnessFactorsQuery);

            var createTableVillainsQuery = @"CREATE TABLE Villains(
                                            	Id INT PRIMARY KEY IDENTITY,
                                            	[Name] VARCHAR(50) NOT NULL,
                                            	EvilnessFactorId INT NOT NULL REFERENCES EvilnessFactors(Id)
                                            )";
            CreateTable(sqlConnectionMinionsDB, createTableVillainsQuery);

            var createTableMinionsVillainsQuery = @"CREATE TABLE MinionsVillains(
                                                    	MinionId INT NOT NULL REFERENCES Minions(Id),
                                                    	VillainId INT NOT NULL REFERENCES Villains(Id),
                                                    	PRIMARY KEY(MinionId, VillainId)
                                                    )";
            CreateTable(sqlConnectionMinionsDB, createTableMinionsVillainsQuery);

            var countriesInsertQuery = @"INSERT INTO Countries([Name])
	                                        VALUES ('Bulgaria'),
	                                        	   ('Serbia'),
	                                        	   ('Romania'),
	                                        	   ('Germani'),
	                                        	   ('Austria')";
            InsertIntoTable(sqlConnectionMinionsDB, countriesInsertQuery);

            var townsInsertQuery = @"INSERT INTO Towns([Name],CountryCode)
	                                        VALUES ('Burgas', 1),
	                                               ('Belgrade', 2),
	                                        	   ('Bucurest', 3),
	                                        	   ('Berlin', 4),
	                                        	   ('Salzburg', 5)";
            InsertIntoTable(sqlConnectionMinionsDB, townsInsertQuery);

            var minionsInsertQuery = @"INSERT INTO Minions([Name], Age, TownId)
	                                        VALUES ('Peter', 14, 1),
	                                               ('Mladen', 13, 2),
	                                        	   ('Asen', 17, 3),
	                                        	   ('Gosho', 12, 4),
	                                        	   ('Dilan', 18, 5)";
            InsertIntoTable(sqlConnectionMinionsDB, minionsInsertQuery);

            var evilnessFactorsInsertQuery = @"INSERT INTO EvilnessFactors([Name])
	                                                VALUES ('not evil'),
	                                                       ('kind evil'),
	                                                	   ('evil'),
	                                                	   ('medium evil'),
	                                                	   ('bad evil')";
            InsertIntoTable(sqlConnectionMinionsDB, evilnessFactorsInsertQuery);

            var villainsInsertQuery = @"INSERT INTO Villains([Name],EvilnessFactorId)
	                                        VALUES ('Chubaka', 1),
	                                               ('Hitler', 2),
	                                        	   ('Voldemort', 3),
	                                        	   ('DarthVader', 4),
	                                        	   ('Loki', 5)";
            InsertIntoTable(sqlConnectionMinionsDB, villainsInsertQuery);

            var minionsVillainsInsertQuery = @"INSERT INTO MinionsVillains(MinionId, VillainId)
	                                                VALUES (1, 1),
	                                                       (2, 1),
	                                                	   (3, 1),
	                                                	   (1, 2),
	                                                	   (1, 3)";
            InsertIntoTable(sqlConnectionMinionsDB, minionsVillainsInsertQuery);
        }

        public static void CreateTable(SqlConnection sqlConnection, string tableQuery)
        {
            using var myCommand = new SqlCommand(tableQuery, sqlConnection);
            myCommand.ExecuteNonQuery();
        }

        public static void CreateDatabase(SqlConnection sqlConnection, string databaseQuery)
        {
           using var myCommand = new SqlCommand(databaseQuery, sqlConnection);
            myCommand.ExecuteNonQuery();
        }

        public static void InsertIntoTable(SqlConnection sqlConnection, string insertQuery)
        {
            using var myCommand = new SqlCommand(insertQuery, sqlConnection);
            myCommand.ExecuteNonQuery();
        }
    }
}
