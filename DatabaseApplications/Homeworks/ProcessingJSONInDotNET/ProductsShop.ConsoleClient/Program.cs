namespace ProductsShop.ConsoleClient
{
    using ProductsShop.Data;
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using System.IO;
    using System.Xml.Serialization;
    using ProductsShop.Models;
    using System.Xml.Linq;
    using System.Xml;

    class Program
    {
        //private const decimal MinPrice = 500;
        //private const decimal MaxPrice = 1000;

        static void Main(string[] args)
        {
            var context = new ProductsShopContext();
            //var products = context.Products
            //    .Where(p => MinPrice <= p.Price && p.Price <= MaxPrice && p.BuyerId == null)
            //    .Select(p => new
            //    {
            //        name = p.Name,
            //        price = p.Price,
            //        seller = p.Seller.FirstName + " " + p.Seller.LastName
            //    });
            //string json = JsonConvert.SerializeObject(products, Formatting.Indented);

            //File.WriteAllText("../../products-in-range.json", json);

            //var users = context.Users
            //    .Where(u => u.SoldProducts.Count > 0)
            //    .OrderBy(u => u.LastName)
            //    .ThenBy(u => u.FirstName)
            //    .Select(u => new
            //    {
            //        firstName = u.FirstName,
            //        lastName = u.LastName,
            //        soldProducts = u.SoldProducts
            //        .Where(sp => sp.BuyerId != null)
            //        .Select(sp => new
            //        {
            //            name = sp.Name,
            //            price = sp.Price,
            //            buyerFirstName = sp.Buyer.FirstName,
            //            buyerLastName = sp.Buyer.LastName
            //        })
            //    });
            //string json = JsonConvert.SerializeObject(users, Formatting.Indented);

            //File.WriteAllText("../../users-sold-products.json", json);

            //var categories = context.Categories
            //    .OrderBy(c => c.Products.Count)
            //    .Select(c => new
            //    {
            //        category = c.Name,
            //        productsCount = c.Products.Count,
            //        averagePrice = c.Products.Average(p => p.Price),
            //        totalRevenue = c.Products.Sum(p => p.Price)
            //    });
            //string json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            //File.WriteAllText("../../categories-by-products.json", json);

            var users = context.Users
                .Where(u => u.SoldProducts.Count > 0)
                .OrderByDescending(u => u.SoldProducts.Count)
                .ThenBy(u => u.LastName)
                .Select(u => new
                {
                    FirstName = u.FirstName == null ? null : u.FirstName,
                    u.LastName,
                    Age = u.Age == null ? null : u.Age,
                    SoldProducts = u.SoldProducts
                    .Select(sp => new
                    {
                        sp.Name,
                        sp.Price
                    })
                });

            var settings = new XmlWriterSettings()
            {
                Indent = true,
                NewLineChars = "\n"
            };
            
            using (XmlWriter writer = XmlWriter.Create("../../users-and-products.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("users");
                writer.WriteAttributeString("count", users.Count().ToString());

                foreach (var user in users)
                {
                    writer.WriteStartElement("user");

                    if (user.FirstName != null && user.Age != null)
                    {
                        writer.WriteAttributeString("first-name", user.FirstName);
                        writer.WriteAttributeString("last-name", user.LastName);
                        writer.WriteAttributeString("age", user.Age.ToString());
                    }

                    foreach (var soldProduct in user.SoldProducts)
                    {
                        writer.WriteStartElement("product");
                        writer.WriteAttributeString("name", soldProduct.Name);
                        writer.WriteAttributeString("price", soldProduct.Price.ToString());
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
