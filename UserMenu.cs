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
            List<string> products = new List<string>();
            List<string> orders = new List<string>();

            products.Add("Bread|30");
            products.Add("Mineral Water|20");
            products.Add("Rebisco Chocolate Flavor|50");

            int choice = 0;

            while (choice != 3)
            {
                Console.WriteLine("\nORDER MENU");
                Console.WriteLine("1. Order");
                Console.WriteLine("2. Display Order");
                Console.WriteLine("3. Logout");

                Console.Write("Select an option: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Order(products, orders);
                        break;

                    case 2:
                        DisplayOrder(orders);
                        break;

                    case 3:
                        Console.WriteLine("Logged out!");
                        break;

                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }

        static void Order(List<string> products, List<string> orders)
        {
            Console.WriteLine("\nPRODUCT LIST");

            for (int i = 0; i < products.Count; i++)
            {
                string[] info = products[i].Split('|');

                Console.WriteLine((i + 1) + ". Product Name: " +
                    info[0] + "\n   Quantity: " + info[1]);
            }

            Console.Write("\nEnter product number: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice >= 1 && choice <= products.Count)
            {
                Console.Write("Enter quantity: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                string[] info = products[choice - 1].Split('|');
                int stock = Convert.ToInt32(info[1]);

                if (quantity > 0 && quantity <= stock)
                {
                    stock = stock - quantity;

                    products[choice - 1] = info[0] + "|" + stock;

                    orders.Add(info[0] + "|" + quantity);

                    Console.WriteLine("Order has been successfully created!");

                    Console.WriteLine("\nORDER DETAILS");
                    Console.WriteLine("Product Name: " + info[0]);
                    Console.WriteLine("Quantity: " + quantity);
                }
                else
                {
                    Console.WriteLine("Invalid quantity or insufficient stock!");
                }
            }
            else
            {
                Console.WriteLine("Invalid product number!");
            }
        }

        static void DisplayOrder(List<string> orders)
        {
            Console.WriteLine("\nORDER LIST");

            if (orders.Count > 0)
            {
                foreach (string order in orders)
                {
                    string[] info = order.Split('|');

                    Console.WriteLine("Product Name: " + info[0]);
                    Console.WriteLine("Quantity: " + info[1]);
                }
            }
            else
            {
                Console.WriteLine("No orders found.");
            }
        }
    }
}