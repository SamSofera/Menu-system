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

                choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddProducts(products, loggedInUser);
                        break;
                    case "2":
                        DisplayProducts(products);
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("Invalid input\n");
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
                Console.Write(i + ". Please enter the name of the product: ");
                var name = Console.ReadLine();

                Console.Write(i + ". Please enter the quantity of the product: ");
                var quantity = Console.ReadLine();

                var createdDate = DateTime.Now.ToString("M/d/yyyy h:mm tt");

                products.Add("Product Name: " + name + "\n" +
                             "Quantity: " + quantity + "\n" +
                             "Active: Yes\n" +
                             "Created Date: " + createdDate + "\n" +
                             "Created By: " + user);
            }

            Console.WriteLine("All products have been successfully created.\n");
        }

        public static void DisplayProducts(List<string> product)
        {
            if (product.Count == 0)
            {
                Console.WriteLine("No Record found\n");
                return;
            }

            foreach (var products in product)
            {
                Console.WriteLine(products);
                Console.WriteLine();
            }
        }
    }
    
}
