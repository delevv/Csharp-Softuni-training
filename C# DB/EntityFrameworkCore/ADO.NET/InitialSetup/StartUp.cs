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

        }

        public static void CreateTable(SqlConnection sqlConnection, string tableQuery)
        {
            var myCommand = new SqlCommand(tableQuery, sqlConnection);
            myCommand.ExecuteNonQuery();
        }

        public static void CreateDatabase(SqlConnection sqlConnection, string databaseQuery)
        {
            var myCommand = new SqlCommand(databaseQuery, sqlConnection);
            myCommand.ExecuteNonQuery();
        }
    }
}
