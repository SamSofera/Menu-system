using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinalProject
{
    public class UserMenu
    {
        public UserMenu(User loggedInUser)
        {
            string choice = "";

            while (choice != "3")
            {
                Console.WriteLine("\nORDER MENU");
                Console.WriteLine("1. Order");
                Console.WriteLine("2. Display Order");
                Console.WriteLine("3. Logout");

                Console.Write("\nSelect an option: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateOrder(DataStorage.Products, DataStorage.Orders);
                        break;
                    case "2":
                        DisplayOrders(DataStorage.Orders);
                        break;
                    case "3":
                        Console.WriteLine("Logged out!");
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }

        static void CreateOrder(List<Product> products, List<Order> orders)
        {
            if (products.Count == 0)
            {
                Console.WriteLine("\nNo products available.");
                return;
            }

            Console.WriteLine("\nPRODUCT LIST");

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine((i + 1) + ". Product Name: " + products[i].Name +
                                  "\n   Quantity: " + products[i].Quantity);
            }

            Console.Write("\nEnter product number: ");
            int choice;

            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > products.Count)
            {
                Console.WriteLine("Invalid product number!");
                return;
            }

            Product selected = products[choice - 1];

            Console.Write("Enter quantity: ");
            int quantity;

            if (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0 || quantity > selected.Quantity)
            {
                Console.WriteLine("Invalid quantity or insufficient stock!");
                return;
            }

            selected.Quantity -= quantity;

            orders.Add(new Order
            {
                ProductName = selected.Name,
                Quantity = quantity
            });

            Console.WriteLine("Order has been successfully created!");
            Console.WriteLine("\nORDER DETAILS");
            Console.WriteLine("Product Name: " + selected.Name);
            Console.WriteLine("Quantity: " + quantity);
        }

        public static void DisplayOrders(List<Order> orders)
        {
            Console.WriteLine("\nORDER LIST");

            if (orders.Count == 0)
            {
                Console.WriteLine("No orders found.");
                return;
            }

            foreach (Order order in orders)
            {
                Console.WriteLine("Product Name: " + order.ProductName);
                Console.WriteLine("Quantity: " + order.Quantity);
            }
        }
    }
}
