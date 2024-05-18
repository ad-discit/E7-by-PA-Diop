using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace E7ByPADiop
{
    public static class TransactionExamples
    {
        private const string ConnectionString = "server=localhost;user=root;database=e7db;port=3306;password=AD50GDUSP";

        public static void ShowTransactions()
        {
            Console.WriteLine("Welcome, student! Today, we're going to see how a transaction works in the Call of Duty in-game marketplace.");
            Console.WriteLine();
            Console.WriteLine("Scenario: An online player wants to buy a weapon from the marketplace.");
            Console.WriteLine("Here are the code steps for our transaction:");
            Console.WriteLine("1. Recon: Check if the player has enough COD Points.");
            Console.WriteLine("2. Deduction: Subtract the weapon cost from the player's balance.");
            Console.WriteLine("3. Acquisition: Add the weapon to the player's inventory.");
            Console.WriteLine("4. Execute: Commit the transaction if all operations succeed.");
            Console.WriteLine("5. Abort: Rollback the transaction if any operation fails.");
            Console.WriteLine();
            Console.WriteLine("Now, let's get into the code for this example:");

            Console.WriteLine(@"
using (var connection = new MySqlConnection(ConnectionString))
{
    connection.Open();
    MySqlTransaction transaction = connection.BeginTransaction();

    try
    {
        // Assume player ID is 1 and weapon ID is 42
        int playerId = 1;
        int weaponId = 42;
        decimal weaponPrice = 1500.0m; // Cost in COD Points

        // Step 1: Recon - Check if the player has enough COD Points
        string checkBalanceQuery = ""SELECT balance FROM players WHERE id = @playerId"";
        MySqlCommand checkBalanceCommand = new MySqlCommand(checkBalanceQuery, connection, transaction);
        checkBalanceCommand.Parameters.AddWithValue(""@playerId"", playerId);
        decimal playerBalance = (decimal)checkBalanceCommand.ExecuteScalar();

        if (playerBalance < weaponPrice)
        {
            throw new Exception(""Mission failed: Insufficient COD Points"");
        }

        // Step 2: Deduction - Subtract the weapon cost from the player's balance
        string deductBalanceQuery = ""UPDATE players SET balance = balance - @weaponPrice WHERE id = @playerId"";
        MySqlCommand deductBalanceCommand = new MySqlCommand(deductBalanceQuery, connection, transaction);
        deductBalanceCommand.Parameters.AddWithValue(""@weaponPrice"", weaponPrice);
        deductBalanceCommand.Parameters.AddWithValue(""@playerId"", playerId);
        deductBalanceCommand.ExecuteNonQuery();

        // Step 3: Acquisition - Add the weapon to the player's inventory
        string addItemQuery = ""INSERT INTO inventory (player_id, item_id) VALUES (@playerId, @weaponId)"";
        MySqlCommand addItemCommand = new MySqlCommand(addItemQuery, connection, transaction);
        addItemCommand.Parameters.AddWithValue(""@playerId"", playerId);
        addItemCommand.Parameters.AddWithValue(""@weaponId"", weaponId);
        addItemCommand.ExecuteNonQuery();

        // Step 4: Execute - Commit the transaction
        transaction.Commit();
        Console.WriteLine(""Mission accomplished: Transaction committed successfully."");
    }
    catch (Exception ex)
    {
        // Step 5: Abort - Rollback the transaction if any operation fails
        try
        {
            transaction.Rollback();
            Console.WriteLine(""Mission aborted: Transaction rolled back due to an error: "" + ex.Message);
        }
        catch (Exception rollbackEx)
        {
            Console.WriteLine(""Abort error: "" + rollbackEx.Message);
        }
    }
}
");
        }
    }
}
