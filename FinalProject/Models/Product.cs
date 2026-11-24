using System;

namespace FinalProject
{
    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public bool IsActive
        {
            get { return Quantity > 0; }
        }

        public Product()
        { }
    }
}
