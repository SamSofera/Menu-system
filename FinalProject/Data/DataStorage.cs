using System;
using System.Collections.Generic;

namespace FinalProject
{
    public static class DataStorage
    {
        public static List<User> Users = new List<User>();
        public static List<Product> Products = new List<Product>();
        public static List<Order> Orders = new List<Order>();

        static DataStorage()
        {
            Users.Add(new User { Username = "Sam", Password = "ABCD", Role = "Admin", IsActive = true });
            Users.Add(new User { Username = "Allen", Password = "ABC", Role = "Warehouse", IsActive = true });
            Users.Add(new User { Username = "Diddy", Password = "XYZ", Role = "User", IsActive = true });

            DateTime startDate = new DateTime(2026, 11, 25, 4, 1, 4);

            Products.Add(new Product { Name = "Bread", Quantity = 30, CreatedDate = startDate, CreatedBy = "Allen" });
            Products.Add(new Product { Name = "Mineral Water", Quantity = 20, CreatedDate = startDate, CreatedBy = "Allen" });
            Products.Add(new Product { Name = "Rebisco Chocolate Flavor", Quantity = 50, CreatedDate = startDate, CreatedBy = "Allen" });
        }
    }
}
