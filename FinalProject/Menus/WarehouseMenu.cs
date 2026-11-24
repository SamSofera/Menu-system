using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
                string name = "";
                bool validName = false;

                while (!validName)
                {
                    Console.Write(i + ". Please enter the name of the product: ");
                    name = (Console.ReadLine() ?? "").Trim();

                    if (name == "")
                    {
                        Console.WriteLine("Product name cannot be empty.");
                    }
                    else
                    {
                        validName = true;
                    }
                }

                string quantityText = "";
                bool validQuantity = false;

                while (!validQuantity)
                {
                    Console.Write(i + ". Please enter the quantity of the product: ");
                    quantityText = (Console.ReadLine() ?? "").Trim();

                    if (IsNumber(quantityText) && quantityText.Length <= 6)
                    {
                        validQuantity = true;
                    }
                    else
                    {
                        Console.WriteLine("\nQuantity must be a whole number.");
                    }
                }

                int amount = int.Parse(quantityText);

                Product existing = FindProduct(products, name);

                if (existing == null)
                {
                    products.Add(new Product
                    {
                        Name = name,
                        Quantity = amount,
                        CreatedDate = DateTime.Now,
                        CreatedBy = user.Username
                    });
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
                if (string.Equals(product.Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    return product;
                }
            }

            return null;
        }

        static bool IsNumber(string text)
        {
            if (text == "")
            {
                return false;
            }

            foreach (char c in text)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return true;
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
