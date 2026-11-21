using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinalProject
{
    public class AdminMenu
    {
        public AdminMenu(User loggedInUser)
        {
            string choice = "";

            while (choice != "9")
            {
                Console.WriteLine("1. Update Password");
                Console.WriteLine("2. Inactivate User");
                Console.WriteLine("3. Add User");
                Console.WriteLine("4. Display All Users");
                Console.WriteLine("5. Display Inactive Users");
                Console.WriteLine("6. Display Active Users");
                Console.WriteLine("7. Display Products");
                Console.WriteLine("8. Display Orders");
                Console.WriteLine("9. Logout");
                Console.WriteLine();

                choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        UpdatePassword(loggedInUser);
                        break;
                    case "2":
                        InactivateUsers(loggedInUser);
                        break;
                    case "3":
                        AddUser();
                        break;
                    case "4":
                        DisplayAllUsers();
                        break;
                    case "5":
                        DisplayInactiveUsers();
                        break;
                    case "6":
                        DisplayActiveUsers();
                        break;
                    case "7":
                        WarehouseMenu.DisplayProducts.DisplayProduct(DataStorage.Products);
                        break;
                    case "8":
                        UserMenu.DisplayOrders.DisplayOrder(DataStorage.Orders);
                        break;
                    case "9":
                        Console.WriteLine("Thank you for using the System Menu.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 9.");
                        break;
                }
                Console.WriteLine();
            }
        }

        public void UpdatePassword(User loggedInUser)
        {
            List<User> choices = new List<User>();
            choices.Add(loggedInUser);

            foreach (var user in DataStorage.Users)
            {
                if (user.IsActive == true && user != loggedInUser)
                {
                    choices.Add(user);
                }
            }

            for (int i = 0; i < choices.Count; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("1. My account");
                }
                else
                {
                    Console.WriteLine((i + 1) + ". " + choices[i].Username + "_" + choices[i].Role);
                }
            }

            Console.WriteLine();
            Console.Write("Please select a user: ");
            var input = Console.ReadLine();

            User selectedUser = null;
            for (int i = 0; i < choices.Count; i++)
            {
                if (input == (i + 1).ToString())
                {
                    selectedUser = choices[i];
                }
            }

            if (selectedUser == null)
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            Console.Write("Please enter the new password for user " + selectedUser.Username + "_" + selectedUser.Role + ": ");
            var newPassword = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                Console.WriteLine("Password cannot be empty.");
                return;
            }

            if (newPassword == selectedUser.Password)
            {
                Console.WriteLine("New password cannot be the same as the previous password.");
                return;
            }

            Console.Write("Please confirm the password: ");
            var confirmPassword = Console.ReadLine();

            if (newPassword != confirmPassword)
            {
                Console.WriteLine("Passwords do not match. Password was not changed.");
                return;
            }

            selectedUser.Password = newPassword;
            Console.WriteLine("Password updated successfully.");
        }

        public void DisplayAllUsers()
        {
            foreach (var user in DataStorage.Users)
            {
                Console.WriteLine($"Username: {user.Username}_{user.Role}, Role: {user.Role}, Active: {user.IsActive}");
            }
        }

        public void DisplayInactiveUsers()
        {
            int count = 0;
            foreach (var user in DataStorage.Users.Where(u => !u.IsActive))
            {
                count++;
                Console.WriteLine($"Username: {user.Username}_{user.Role}, Role: {user.Role}, Active: {user.IsActive}");
            }

            if (count == 0)
            {
                Console.WriteLine("No Inactive users found.");
            }
        }

        public void DisplayActiveUsers()
        {
            int activeCount = 0;

            foreach (var user in DataStorage.Users.Where(u => u.IsActive))
            {
                activeCount++;
                Console.WriteLine($"Username: {user.Username}_{user.Role}, Role: {user.Role}, Active: {user.IsActive}");
            }

            if (activeCount == 0)
            {
                Console.WriteLine("No Active users found.");
            }
        }

        public void AddUser()
        {
            Console.Write("Enter new username: ");
            var newUsername = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(newUsername))
            {
                Console.WriteLine("Username cannot be empty.");
                return;
            }

            Console.Write("Enter new password: ");
            var newPassword = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                Console.WriteLine("Password cannot be empty.");
                return;
            }

            Console.Write("Enter role (Admin/Warehouse/User): ");
            var roleInput = Console.ReadLine().ToLower().Trim();

            string newRole = "";

            if (roleInput == "admin")
            {
                newRole = "Admin";
            }
            else if (roleInput == "warehouse")
            {
                newRole = "Warehouse";
            }
            else if (roleInput == "user")
            {
                newRole = "User";
            }
            else
            {
                Console.WriteLine("Invalid role. Must be Admin, Warehouse, or User.");
                return;
            }

            foreach (var user in DataStorage.Users)
            {
                if (string.Equals(user.Username, newUsername, StringComparison.OrdinalIgnoreCase) && user.Role == newRole)
                {
                    Console.WriteLine("Username already exists for that role.");
                    return;
                }
            }

            DataStorage.Users.Add(new User
            {
                Username = newUsername,
                Password = newPassword,
                Role = newRole,
                IsActive = true
            });

            Console.WriteLine("User added successfully.");
        }


        public void InactivateUsers(User loggedInUser)
        {
            List<User> choices = new List<User>();
            foreach (var user in DataStorage.Users)
            {
                if (user.IsActive == true && user != loggedInUser)
                {
                    choices.Add(user);
                }
            }
            if (choices.Count == 0)
            {
                Console.WriteLine("No active users available to inactivate.");
                return;
            }
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + choices[i].Username + "_" + choices[i].Role);
            }

            Console.WriteLine();
            Console.Write("Please select a user to inactivate: ");
            var input = Console.ReadLine();

            User selectedUser = null;

            for (int i = 0; i < choices.Count; i++)
            {
                if (input == (i + 1).ToString())
                {
                    selectedUser = choices[i];
                }
            }
            if (selectedUser == null)
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            selectedUser.IsActive = false;
            Console.WriteLine($"User {selectedUser.Username}_{selectedUser.Role} has been inactivated.");
        }
    }
}
