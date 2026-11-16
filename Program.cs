using System;
using System.Linq;

namespace FinalProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                User loggedInUser = null;

                while (loggedInUser == null)
                {
                    Console.WriteLine("Please select a user role to login:");
                    Console.WriteLine("1. Admin");
                    Console.WriteLine("2. Warehouse");
                    Console.WriteLine("3. User");
                    Console.WriteLine();

                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            loggedInUser = Login("Admin");
                                if (loggedInUser != null && loggedInUser.Role == "Admin")
                            {
                                AdminMenu adminMenu = new AdminMenu(loggedInUser);      
                            }
                            break;
                        case "2":
                            loggedInUser = Login("Warehouse");
                            break;
                        case "3":
                            loggedInUser = Login("User");
                                if (loggedInUser != null && loggedInUser.Role == "User")
                            {
                                UserMenu userMenu = new UserMenu(loggedInUser);
                            }
                            break;
                        default:
                            Console.WriteLine("\nInvalid choice. Please try again.\n");
                            break;
                    }
                }
            }
        }

        private static User Login(string role)
        {
                Console.Write("Please enter your username: ");
                var username = Console.ReadLine();
                Console.Write("Please enter your password: ");
                var password = Console.ReadLine();

                foreach (var user in DataStorage.Users)
                {
                    string fullUsername = user.Username + "_" + user.Role;
                    string fullPassword = user.Username + "_" + user.Password;

                        if (fullUsername == username && fullPassword == password && user.Role == role)
                        {
                            if (user.IsActive == true)
                            {
                                Console.WriteLine("\nLogin successful! Welcome, " + fullUsername + ".\n");
                                return user;
                            }
                            else
                            {
                                Console.WriteLine("\nUser is inactive. Please contact administrator.\n");
                                return null;
                            }
                        }
                    }
                
            Console.WriteLine("\nInvalid credentials or role. Please try again.\n");
            return null;
        }
    }
}
