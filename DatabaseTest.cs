using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using MySql.Data.MySqlClient;

namespace E7ByPADiop
{
    public static class DatabaseTest
    {
        private const string ConnectionString = "server=localhost;user=root;database=e7db;port=3306;password=AD50GDUSP";

        public static void TestConnection()
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection to database 'e7db' was successful.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}

