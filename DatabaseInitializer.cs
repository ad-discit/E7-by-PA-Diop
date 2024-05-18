using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace E7ByPADiop
{
    public static class DatabaseManagement
    {
        private const string ServerConnectionString = "server=localhost;user=root;port=3306;password=AD50GDUSP";
        private const string DatabaseConnectionString = "server=localhost;user=root;database=e7db;port=3306;password=AD50GDUSP";

        public static void CreateDatabase()
        {
            string query = "CREATE DATABASE IF NOT EXISTS e7db";

            using (var connection = new MySqlConnection(ServerConnectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Database 'e7db' created or already exists.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public static void CreateTable()
        {
            string query = @"
                CREATE TABLE IF NOT EXISTS mytable (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    name VARCHAR(50),
                    value INT
                )";

            using (var connection = new MySqlConnection(DatabaseConnectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Table 'mytable' created or already exists in database 'e7db'.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
