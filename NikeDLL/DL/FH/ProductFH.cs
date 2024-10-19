using NikeDLL.BL;
using NikeDLL.DLInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace NikeDLL.DL.FH
{
    public class ProductFH : IProductDL
    {
        string filePath = "tracksuits.txt";
        public ProductFH(string filePath)
        {
            this.filePath = filePath;
        }
        private List<ProductBL> products = new List<ProductBL>();
        public void WriteToFile()
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (var product in products)
                {
                    sw.WriteLine($"{product.Name},{product.Color},{product.Size},{product.Quantity},{product.Price}");
                }
            }

        }
        public void ReadFromFile()
        {
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 5)
                        {
                            string name = parts[0];
                            string color = parts[1];
                            string size = parts[2];
                            int quantity;
                            if (int.TryParse(parts[3], out quantity))
                            {
                                decimal price;
                                if (decimal.TryParse(parts[4], out price))
                                {
                                    products.Add(new ProductBL(name, color, size, quantity, price));
                                }
                            }
                        }
                    }
                }

            }
            else
            {
            }
        }
        public void AddProduct(ProductBL product)
        {
            products.Add(product);
            WriteToFile();
        }
        public List<ProductBL> GetProducts()
        {
            return products;
        }
        public bool DeleteProductByName(string name)
        {
            ProductBL productToDelete = products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (productToDelete != null)
            {
                products.Remove(productToDelete);
                WriteToFile();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateProductQuantityByName(string name, int newQuantity)
        {
            ProductBL productToUpdate = products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (productToUpdate != null)
            {
                productToUpdate.Quantity = newQuantity;
                WriteToFile();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddSuit(string name, string size, string color, int quantity, decimal price)
        {
            throw new NotImplementedException();
        }

        public void UpdateSuit(int suitID, int quantity, decimal price)
        {
            throw new NotImplementedException();
        }

        public void DeleteSuit(int suitID)
        {
            throw new NotImplementedException();
        }

        public bool AddFeedback(string name, string feedbackText, int rating)
        {
            throw new NotImplementedException();
        }

        public bool EmptyCartTables()
        {
            throw new NotImplementedException();
        }

        public decimal CalculateTotalPayableAmount()
        {
            throw new NotImplementedException();
        }

        public bool DeleteFromSuitCart(int SuitID)
        {
            throw new NotImplementedException();
        }

        public DataTable GetSuitCart()
        {
            throw new NotImplementedException();
        }

        public decimal GetSuitPrice(int SuitID)
        {
            throw new NotImplementedException();
        }

        public bool AddToSuitCart(int SuitID, int quantity, decimal price)
        {
            throw new NotImplementedException();
        }

        public DataTable GetFeedback()
        {
            throw new NotImplementedException();
        }

        public DataTable ShowAllSuits()
        {
            throw new NotImplementedException();
        }
    }
}
