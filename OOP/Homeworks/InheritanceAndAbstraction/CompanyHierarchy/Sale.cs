using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    class Sale : ISale
    {
        private string productName;
        private decimal price;
        public string ProductName
        {
            get
            {
                return this.productName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Product Name cannot be empty.");
                }
                this.productName = value;
            }
        }
        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Price must be greater than 0.");
                }
                this.price = value;
            }
        }
        public DateTime Date { get; set; }
        public Sale(string productName, DateTime date, decimal price)
        {
            this.ProductName = productName;
            this.Date = date;
            this.Price = price;
        }
        public override string ToString()
        {
            return String.Format("Sale: Product Name: {0}; Date: {1}; Price: {2}", this.productName, this.Date, this.price);
        }
    }
}
