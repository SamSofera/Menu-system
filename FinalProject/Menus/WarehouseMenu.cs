using System;
using System.Collections.Generic;

namespace FinalProject
{
    public class WarehouseMenu
    {
        public WarehouseMenu(User loggedInUser)
        {
            Console.WriteLine("WAREHOUSE ROLE");

            string choice = "";

            while (choice != "3")
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Add Products");
                Console.WriteLine("2. Display Products");
                Console.WriteLine("3. Logout");
                Console.WriteLine();

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProducts(DataStorage.Products, loggedInUser);
                        break;
                    case "2":
                        DisplayProducts(DataStorage.Products);
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("\nInvalid input");
                        break;
                }
            }
        }

        public static void AddProducts(List<Product> products, User user)
        {
            Console.Write("Please enter the number of products you want to add: ");
            int count;

            while (!int.TryParse(Console.ReadLine(), out count) || count < 1)
            {
                Console.Write("Please enter a whole number greater than 0: ");
            }

            for (int i = 1; i <= count; i++)
            {
                Console.Write(i + ". Please enter the name of the product: ");
                string name = Console.ReadLine().Trim();

                while (name == "")
                {
                    Console.WriteLine("Product name cannot be empty.");
                    Console.Write(i + ". Please enter the name of the product: ");
                    name = Console.ReadLine().Trim();
                }

                Console.Write(i + ". Please enter the quantity of the product: ");
                int amount;

                while (!int.TryParse(Console.ReadLine(), out amount) || amount < 0)
                {
                    Console.WriteLine("\nQuantity must be a whole number.");
                    Console.Write(i + ". Please enter the quantity of the product: ");
                }

                Product existing = FindProduct(products, name);

                if (existing == null)
                {
                    Product newProduct = new Product();
                    newProduct.Name = name;
                    newProduct.Quantity = amount;
                    newProduct.CreatedDate = DateTime.Now;
                    newProduct.CreatedBy = user.Username;
                    products.Add(newProduct);
                }
                else
                {
                    existing.Quantity += amount;
                    Console.WriteLine(existing.Name + " already exists. Quantity was added. New quantity: " + existing.Quantity);
                }
            }

            Console.WriteLine("\nAll products have been successfully created or updated.");
        }

        static Product FindProduct(List<Product> products, string name)
        {
            foreach (Product product in products)
            {
                if (product.Name.ToLower() == name.ToLower())
                {
                    return product;
                }
            }

            return null;
        }

        public static void DisplayProducts(List<Product> products)
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No Record found\n");
                return;
            }

            foreach (Product product in products)
            {
                Console.WriteLine("Product Name: " + product.Name);
                Console.WriteLine("Quantity: " + product.Quantity);
                Console.WriteLine("Active: " + product.IsActive);
                Console.WriteLine("Created Date: " + product.CreatedDate.ToString("M/d/yyyy h:mm tt"));
                Console.WriteLine("Created By: " + product.CreatedBy);
                Console.WriteLine();
            }
        }
    }
}
