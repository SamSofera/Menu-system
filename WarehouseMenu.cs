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

            List<string> products = new List<string>();
            List<string> accounts = new List<string>();

            var choice = "";

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
                        WarehouseMenu.DisplayProducts.DisplayProduct(DataStorage.Products);
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("\nInvalid input");
                        break;
                }
            }
        }

        public static void AddProducts(List<string> products, User user)
        {
            Console.Write("Please enter the number of products you want to add: ");
            var count = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= count; i++)
            {
                string name = "";
                bool validName = false;

                while (validName == false)
                {
                    Console.Write(i + ". Please enter the name of the product: ");
                    name = Console.ReadLine().Trim();

                    if (name == "")
                    {
                        Console.WriteLine("Product name cannot be empty.");
                    }
                    else if (name.Contains("|"))
                    {
                        Console.WriteLine("Product name cannot contain the \"|\" character.");
                    }
                    else
                    {
                        validName = true;
                    }
                }

                string quantity = "";
                bool validQuantity = false;

                while (validQuantity == false)
                {
                    Console.Write(i + ". Please enter the quantity of the product: ");
                    quantity = Console.ReadLine().Trim();

                    if (IsNumber(quantity) && quantity.Length <= 6)
                    {
                        validQuantity = true;
                    }
                    else
                    {
                        Console.WriteLine("\nQuantity must be a whole number.");
                    }
                }

                int amount = Convert.ToInt32(quantity);

                int index = FindProduct(products, name);

                if (index == -1)
                {
                    var createdDate = DateTime.Now.ToString("M/d/yyyy h:mm tt");

                    products.Add(name + "|" + amount + "|" + createdDate + "|" + user.Username);
                }
                else
                {
                    string[] info = products[index].Split('|');
                    int newStock = Convert.ToInt32(info[1]) + amount;

                    products[index] = info[0] + "|" + newStock + "|" + info[2] + "|" + info[3];

                    Console.WriteLine(info[0] + " already exists. Quantity was added. New quantity: " + newStock);
                }
            }

            Console.WriteLine("\nAll products have been successfully created or updated.");
        }

        static int FindProduct(List<string> products, string name)
        {
            for (int i = 0; i < products.Count; i++)
            {
                string[] info = products[i].Split('|');

                if (info[0].ToLower() == name.ToLower())
                {
                    return i;
                }
            }

            return -1;
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

        public class DisplayProducts
        {
            public string Product { get; set; }
            public int Quantity { get; set; }

            public static void DisplayProduct(List<string> product)
            {

                if (product.Count == 0)
                {
                    Console.WriteLine("No Record found\n");
                    return;
                }

                foreach (var products in product)
                {
                    string[] info = products.Split('|');

                    Console.WriteLine("Product Name: " + info[0]);
                    Console.WriteLine("Quantity: " + info[1]);
                    if (info[1] == "0")
                    {
                        Console.WriteLine("Active: False");
                    }
                    else
                    {
                        Console.WriteLine("Active: True");
                    }
                    Console.WriteLine("Created Date: " + info[2]);
                    Console.WriteLine("Created By: " + info[3]);
                    Console.WriteLine();
                }
            }
        }

    }
}
