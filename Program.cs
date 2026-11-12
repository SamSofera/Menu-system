using System;
using System.Linq;

namespace FinalProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            User loggedInUser = null;

            while (loggedInUser == null)
            {
                Console.WriteLine("Please select a user role to login:");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. Warehouse");
                Console.WriteLine("3. User");
                Console.WriteLine();

                var choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        loggedInUser = Login("Admin");
                        break;
                    case 2:
                        loggedInUser = Login("Warehouse");
                        break;
                    case 3:
                        loggedInUser = Login("User");
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.\n");
                        break;
                }
            }

            AdminMenu adminMenu = new AdminMenu(loggedInUser);

        }

        private static User Login(string role)
        {
            Console.Write("Please enter your username: ");
            var username = Console.ReadLine();
            Console.Write("Please enter your password: ");
            var password = Console.ReadLine();

            var user = DataStorage.Users.FirstOrDefault(u =>
                u.Username == username && u.Password == password &&
                u.Role == role && u.IsActive);

            if (user != null)
            {
                Console.WriteLine($"\nLogin successful! Welcome, {user.Username}_{user.Role}.\n");
                return user;
            }

            else if (DataStorage.Users.Any(u =>
                u.Username == username && u.Password == password &&
                u.Role == role && !u.IsActive))
            {
                Console.WriteLine("\nUser is inactive. Please contact administrator.\n");
                return null;
            }
            else
            {
                Console.WriteLine("\nInvalid credentials or role. Please try again.\n");
                return null;
            }
        }
    }
}
