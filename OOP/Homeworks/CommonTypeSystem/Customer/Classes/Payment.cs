using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Customer.Classes
{
    class Payment
    {
        public Payment(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return String.Format("Product Name: {0}; Price: {1};", this.ProductName, this.Price);
        }
    }
}
