﻿namespace CollectionOfProducts
{
    using System;

    class Product : IComparable<Product>
    {
        private static int id;

        public Product(string title, string supplier, decimal price)
        {
            this.Id = ++id;
            this.Title = title;
            this.Supplier = supplier;
            this.Price = price;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Supplier { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(Product other)
        {
            return this.Id.CompareTo(other.Id);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", this.Id, this.Title, this.Supplier, this.Price);
        }
    }
}
