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
                    // Update Password logic
                    break;
                case 2:
                    // Inactivate User logic
                    break;
                case 3:
                    // Add User logic
                    break;
                case 4:

                    foreach (var user in DataStorage.Users)
                    {
                        Console.WriteLine($"Username: {user.Username}_{user.Role}, Role: {user.Role}, Active: {user.IsActive}");
                    }
                    break;
                case 5:
                   
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

                    break;
                case 6:

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
    }
}
