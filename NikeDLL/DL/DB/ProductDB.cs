using NikeDLL.BL;
using NikeDLL.DLInterfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace NikeDLL.DL.DB
{
    public class ProductDB : IProductDL
    {
        private string connectionString;

        public ProductDB(string connectionString)
        {
            this.connectionString = connectionString;
        }
        private bool IsValidSuitColor(string color)
        {
            string[] validColors = { "black", "grey", "blue" };
            return Array.Exists(validColors, c => c.Equals(color, StringComparison.OrdinalIgnoreCase));
        }
        private bool IsValidSuitSize(string size)
        {
            string[] validSize = { "S", "M", "L" };
            return Array.Exists(validSize, t => t.Equals(size, StringComparison.OrdinalIgnoreCase));
        }
        public void AddSuit(string name, string size, string color, int quantity, decimal price)
        {
            if (!IsValidSuitSize(size))
            {
                throw new ArgumentException("Invalid suit size (only small,medium and large)");
            }

            if (!IsValidSuitColor(color))
            {
                throw new ArgumentException("Invalid suit color (only black, grey, blue.");
            }

            string query = "INSERT INTO Suits (Name, Size, Color, Quantity, Price) VALUES ( @Name, @Size, @Color, @Quantity, @Price)";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Size", size);
                    command.Parameters.AddWithValue("@Color", color);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Price", price);

                    command.ExecuteNonQuery();
                }
            }
        }
        public DataTable ShowAllSuits()
        {
            DataTable suitData = new DataTable();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Suits";

                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(suitData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return suitData;
        }
        public void UpdateSuit(int suitID, int quantity, decimal price)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Suits SET Quantity = @Quantity, Price = @Price WHERE suitID = @suitID";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@suitID", suitID);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Price", price);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("suit quantity and price updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No suit found with the provided ID.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public void DeleteSuit(int suitID)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM suits WHERE suitID = @suitID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@suitID", suitID);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception($"No suit found with ID {suitID}.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete suit.", ex);
            }
        }
        public DataTable GetFeedback()
        {
            DataTable feedbackTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Feedbacks";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(feedbackTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving feedback: {ex.Message}");
            }

            return feedbackTable;
        }
        public bool AddToSuitCart(int SuitID, int quantity, decimal price)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM Suits WHERE SuitID = @SuitID";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@SuitID", SuitID);
                    int SuitExists = (int)checkCommand.ExecuteScalar();

                    if (SuitExists == 0)
                    {
                        throw new Exception("The Suit with the provided ID does not exist.");
                    }

                    string insertQuery = "INSERT INTO Cart (SuitID, Quantity, Price) VALUES (@SuitID, @Quantity, @Price)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@SuitID", SuitID);
                    insertCommand.Parameters.AddWithValue("@Quantity", quantity);
                    insertCommand.Parameters.AddWithValue("@Price", price);

                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
        public decimal GetSuitPrice(int SuitID)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Price FROM Suits WHERE SuitID = @SuitID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SuitID", SuitID);

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return -1;
            }
        }
        public DataTable GetSuitCart()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Cart";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                    DataTable SuitCartTable = new DataTable();

                    adapter.Fill(SuitCartTable);

                    return SuitCartTable;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public bool DeleteFromSuitCart(int SuitID)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM Cart WHERE SuitID = @SuitID";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@SuitID", SuitID);
                    int SuitExists = (int)checkCommand.ExecuteScalar();

                    if (SuitExists == 0)
                    {
                        throw new Exception("The Suit with the provided ID does not exist in the cart.");
                    }

                    string deleteQuery = "DELETE FROM Cart WHERE SuitID = @SuitID";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@SuitID", SuitID);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
        public decimal CalculateTotalPayableAmount()
        {
            decimal totalAmount = 0;

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string SuitCartQuery = "SELECT SUM(Price * Quantity) FROM Cart";
                    SqlCommand SuitCartCommand = new SqlCommand(SuitCartQuery, connection);
                    object SuitCartTotal = SuitCartCommand.ExecuteScalar();
                    if (SuitCartTotal != null && SuitCartTotal != DBNull.Value)
                    {
                        totalAmount += Convert.ToDecimal(SuitCartTotal);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return totalAmount;
        }
        public bool EmptyCartTables()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string emptySuitQuery = "DELETE FROM Cart";
                    SqlCommand emptySuitCommand = new SqlCommand(emptySuitQuery, connection);
                    emptySuitCommand.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
        public bool AddFeedback(string name, string feedbackText, int rating)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Feedbacks (CustomerName, FeedbackText, Rating, DateSubmitted) " +
                                         "VALUES (@CustomerName, @FeedbackText, @Rating, GETDATE())";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);

                    insertCommand.Parameters.AddWithValue("@CustomerName", name);
                    insertCommand.Parameters.AddWithValue("@FeedbackText", feedbackText);
                    insertCommand.Parameters.AddWithValue("@Rating", rating);

                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public bool UpdateProductQuantityByName(string name, int newQuantity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(ProductBL product)
        {
            throw new NotImplementedException();
        }

        public void ReadFromFile()
        {
            throw new NotImplementedException();
        }

        public void WriteToFile()
        {
            throw new NotImplementedException();
        }
    }
}
