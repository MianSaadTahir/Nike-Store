using ConsoleNike.UI;
using NikeDLL.DL.FH;
using System;

namespace ConsoleNike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "tracksuits.txt";
            ProductFH productDL = new ProductFH(filePath);
            productDL.ReadFromFile();
            while (true)
            {
                int choice = ProductUI.MainMenu();

                switch (choice)
                {
                    case 1:
                        ProductUI.AddProduct(productDL);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        ProductUI.ViewProducts(productDL);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        ProductUI.UpdateProductQuantity(productDL);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        ProductUI.DeleteProduct(productDL);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        productDL.WriteToFile();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
