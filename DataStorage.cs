using System;
using System.Collections.Generic;

namespace FinalProject
{

    public static class DataStorage
    {
        public static List<User> Users = new List<User>();

        static DataStorage()
        {
            Users.Add(new User { Username = "SamDhaniel", Password = "ABCD1234", Role = "Admin", IsActive = true });
            Users.Add(new User { Username = "Allen", Password = "ABC123", Role = "Warehouse", IsActive = true });
            Users.Add(new User { Username = "JohnDoe", Password = "XYZ789", Role = "User", IsActive = true });
        }
    }
}