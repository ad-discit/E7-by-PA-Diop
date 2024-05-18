using System;

namespace E7ByPADiop
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Create a new user.");
                Console.WriteLine("2. Change the user password.");
                Console.WriteLine("3. Grant permissions to a user for a chosen database.");
                Console.WriteLine("4. Example code to show transactions in a Call of Duty marketplace.");
                Console.WriteLine("5. Test database connection.");
                Console.WriteLine("6. Create database and table.");
                Console.WriteLine("7. Exit.");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        UserManagement.CreateUser();
                        break;
                    case 2:
                        UserManagement.ChangeUserPassword();
                        break;
                    case 3:
                        UserManagement.GrantPermissions();
                        break;
                    case 4:
                        TransactionExamples.ShowTransactions();
                        break;
                    case 5:
                        DatabaseTest.TestConnection();
                        break;
                    case 6:
                        DatabaseManagement.CreateDatabase();
                        DatabaseManagement.CreateTable();
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
