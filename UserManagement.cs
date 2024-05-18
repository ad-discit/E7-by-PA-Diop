using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using MySql.Data.MySqlClient;

namespace E7ByPADiop
{
    public static class UserManagement
    {
        private const string ConnectionString = "server=localhost;user=root;database=e7db;port=3306;password=AD50GDUSP";

        public static void CreateUser()
        {
            Console.Write("Enter new username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password for new user: ");
            string password = Console.ReadLine();

            string query = $"CREATE USER '{username}'@'localhost' IDENTIFIED BY '{password}';";

            ExecuteNonQuery(query, "User created successfully.");
        }

        public static void ChangeUserPassword()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter new password: ");
            string newPassword = Console.ReadLine();

            string query = $"ALTER USER '{username}'@'localhost' IDENTIFIED BY '{newPassword}';";

            ExecuteNonQuery(query, "Password changed successfully.");
        }

        public static void GrantPermissions()
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter database name:");
            string database = Console.ReadLine();

            Console.WriteLine("Select the permission type:");
            Console.WriteLine("1. SELECT");
            Console.WriteLine("2. UPDATE");
            Console.WriteLine("3. INSERT");
            Console.WriteLine("4. DELETE");
            Console.WriteLine("5. CREATE");
            Console.WriteLine("6. DROP");
            Console.WriteLine("7. ALL PRIVILEGES");

            string permission;
            switch (Console.ReadLine())
            {
                case "1":
                    permission = "SELECT";
                    break;
                case "2":
                    permission = "UPDATE";
                    break;
                case "3":
                    permission = "INSERT";
                    break;
                case "4":
                    permission = "DELETE";
                    break;
                case "5":
                    permission = "CREATE";
                    break;
                case "6":
                    permission = "DROP";
                    break;
                case "7":
                    permission = "ALL PRIVILEGES";
                    break;
                default:
                    Console.WriteLine("Invalid option selected. Defaulting to SELECT.");
                    permission = "SELECT";
                    break;
            }

            string sql = $"GRANT {permission} ON {database}.* TO '{username}'@'localhost';";
            ExecuteNonQuery(sql, "Permissions granted successfully.");
        }

        private static void ExecuteNonQuery(string query, string successMessage)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    Console.WriteLine(successMessage);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
