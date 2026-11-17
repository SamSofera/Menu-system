using System;
using System.Collections.Generic;

namespace FinalProject
{

    public static class DataStorage
    {
        public static List<User> Users = new List<User>();
        public static List<string> Products = new List<string>();
        public static List<string> Orders = new List<string>();

        static DataStorage()
        {
            Users.Add(new User { Username = "SamDhaniel", Password = "ABCD1234", Role = "Admin", IsActive = true });
            Users.Add(new User { Username = "Allen", Password = "ABC123", Role = "Warehouse", IsActive = true });
            Users.Add(new User { Username = "JohnDoe", Password = "XYZ", Role = "User", IsActive = true });

            Products.Add("Bread|30|1/1/2026 8:00 AM|Allen");
            Products.Add("Mineral Water|20|1/1/2026 8:00 AM|Allen");
            Products.Add("Rebisco Chocolate Flavor|50|1/1/2026 8:00 AM|Allen");
        }
    }
}
