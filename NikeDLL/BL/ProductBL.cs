using NikeDLL.DL.DB;
using System;
using System.Data;

namespace NikeDLL.BL
{
    public class ProductBL
    {
        private readonly ProductDB productDB;

        public ProductBL(ProductDB productDB)
        {
            this.productDB = productDB;
        }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public ProductBL(string name, string color, string size, int quantity, decimal price)
        {
            Name = name;
            Color = color;
            Size = size;
            Quantity = quantity;
            Price = price;
        }
        public void AddSuit(string name, string size, string color, int quantity, decimal price)
        {

        }

        public void ShowAllSuits()
        {
            productDB.ShowAllSuits();
        }
        public void UpdateSuit(int suitID, int quantity, decimal price)
        {
            productDB.UpdateSuit(suitID, quantity, price);
        }
        public void DeleteSuit(int suitID)
        {
            productDB.DeleteSuit(suitID);
        }
        public bool AddToSuitCart(int suitID, int quantity)
        {
            decimal price = productDB.GetSuitPrice(suitID);

            if (price == -1)
            {
                return false;
            }

            decimal totalPrice = price * quantity;

            return productDB.AddToSuitCart(suitID, quantity, totalPrice);
        }
        public DataTable GetSuitCart()
        {
            return productDB.GetSuitCart();
        }
        public bool DeleteFromSuitCart(int suitID)
        {
            return productDB.DeleteFromSuitCart(suitID);
        }
        public decimal CalculateTotalPayableAmount()
        {
            return productDB.CalculateTotalPayableAmount();
        }
        public bool EmptyCartTables()
        {
            return productDB.EmptyCartTables();
        }
        public bool AddFeedback(string customerName, string feedbackText, int rating)
        {

            return productDB.AddFeedback(customerName, feedbackText, rating);
        }
        public DataTable GetFeedback()
        {
            DataTable feedbackTable = null;
            try
            {
                feedbackTable = productDB.GetFeedback();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while getting feedback: {ex.Message}");
            }
            return feedbackTable;
        }
    }
}
