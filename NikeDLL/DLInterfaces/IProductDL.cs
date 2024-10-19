using NikeDLL.BL;
using System.Data;

namespace NikeDLL.DLInterfaces
{
    public interface IProductDL
    {
        void AddSuit(string name, string size, string color, int quantity, decimal price);
        void UpdateSuit(int suitID, int quantity, decimal price);
        void DeleteSuit(int suitID);
        bool AddFeedback(string name, string feedbackText, int rating);
        bool EmptyCartTables();
        decimal CalculateTotalPayableAmount();
        bool DeleteFromSuitCart(int SuitID);
        DataTable GetSuitCart();
        decimal GetSuitPrice(int SuitID);
        bool AddToSuitCart(int SuitID, int quantity, decimal price);
        DataTable GetFeedback();
        DataTable ShowAllSuits();
        bool UpdateProductQuantityByName(string name, int newQuantity);
        bool DeleteProductByName(string name);
        void AddProduct(ProductBL product);
        void ReadFromFile();
        void WriteToFile();
    }
}
