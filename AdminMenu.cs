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

            var choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    UpdatePassword(loggedInUser);
                    break;
                case 2:
                    // Inactivate User logic
                    break;
                case 3:
                    AddUser();
                    break;
                case 4:
                    DisplayAllUsers();

                    break;
                case 5:
                    DisplayInactiveUsers();

                    break;
                case 6:
                    DisplayActiveUsers();

                    break;
                case 7:
                    // Display Products logic
                    break;
                case 8:
                    // Display Orders logic
                    break;
                case 9:
                    Console.WriteLine("Thank you for using the System Menu.");
                    break;
            }

        }

        public void UpdatePassword(User loggedInUser)
        {
            Console.Write("Enter previous password: ");
            var previousPassword = Console.ReadLine();
            if (previousPassword == loggedInUser.Password)
            {
                Console.Write("Enter new password: ");
                var newPassword = Console.ReadLine();
                loggedInUser.Password = newPassword;
                Console.WriteLine("Password updated successfully.");
            }
            else
            {
                Console.WriteLine("Incorrect previous password.");
            }
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
            var newUsername = Console.ReadLine();
            Console.Write("Enter new password: ");
            var newPassword = Console.ReadLine();
            Console.Write("Enter role (Admin/Warehouse/User): ");
            var newRole = Console.ReadLine();
            DataStorage.Users.Add(new User
            {
                Username = newUsername,
                Password = newPassword,
                Role = newRole,
                IsActive = true
            });
            Console.WriteLine("User added successfully.");
        }   
    }
}
