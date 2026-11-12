using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Program
    {
        static void Main(string[] args)
        {            Console.WriteLine("Please select a user role to login:");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Warehouse");  
            Console.WriteLine("3. User");

            Console.WriteLine();
            var choice = int.Parse(Console.ReadLine());

         
        }
    }
}
