using NikeDLL.BL;
using NikeDLL.DL.FH;
using System;
using System.Collections.Generic;

namespace ConsoleNike.UI
{
    public class ProductUI
    {
        private ProductFH productFH;

        public static int MainMenu()
        {
            Console.WriteLine("---------------NIKE---------------");
            Console.WriteLine();
            Console.WriteLine("1. Add TrackSuit");
            Console.WriteLine("2. View TrackSuits");
            Console.WriteLine("3. Update Stock");
            Console.WriteLine("4. Delete TrackSuit");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            Console.Write("Enter your choice: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                return choice;
            }
            else
            {
                return -1;
            }
        }
        public static void AddProduct(ProductFH productFH)
        {
            Console.Write("Enter TrackSuit name: ");
            string name = Console.ReadLine();

            Console.Write("Enter color: ");
            string color = Console.ReadLine();

            Console.Write("Enter size: ");
            string size = Console.ReadLine();

            int quantity;
            do
            {
                Console.Write("Enter stock quantity: ");
            } while (!int.TryParse(Console.ReadLine(), out quantity));

            decimal price;
            do
            {
                Console.Write("Enter  price: ");
            } while (!decimal.TryParse(Console.ReadLine(), out price));

            productFH.AddProduct(new ProductBL(name, color, size, quantity, price));
            Console.WriteLine();
            Console.WriteLine("TrackSuit added successfully!");

        }
        public static void ViewProducts(ProductFH productFH)
        {
            List<ProductBL> products = productFH.GetProducts();
            Console.WriteLine();
            if (products.Count == 0)
            {
                Console.WriteLine("No TrackSuit available.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("TrackSuit List:");
                Console.WriteLine();
                foreach (var product in products)
                {
                    Console.WriteLine($"Name: {product.Name}, Color: {product.Color}, Size: {product.Size}, Quantity: {product.Quantity}, Price: {product.Price}");
                    Console.WriteLine();
                }
            }
        }
        public static void DeleteProduct(ProductFH productFH)
        {
            Console.WriteLine();
            Console.Write("Enter TrackSuit name to delete: ");
            string nameToDelete = Console.ReadLine();

            bool deleted = productFH.DeleteProductByName(nameToDelete);
            if (deleted)
            {
                Console.WriteLine();
                Console.WriteLine($"TrackSuit '{nameToDelete}' deleted successfully!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"TrackSuit '{nameToDelete}' not found.");
            }
        }
        public static void UpdateProductQuantity(ProductFH productFH)
        {
            Console.WriteLine();
            Console.Write("Enter TrackSuit name to update stock: ");
            string productName = Console.ReadLine();

            Console.Write("Enter new stock quantity: ");
            int newQuantity;
            while (!int.TryParse(Console.ReadLine(), out newQuantity))
            {
                Console.WriteLine();
                Console.WriteLine("Invalid quantity. Please enter a valid integer value.");
                Console.Write("Enter new stock quantity: ");
            }

            bool updated = productFH.UpdateProductQuantityByName(productName, newQuantity);
            if (updated)
            {
                Console.WriteLine();
                Console.WriteLine($"Quantity updated successfully for TrackSuit '{productName}'.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"TrackSuit '{productName}' not found.");

            }
        }
    }
}
