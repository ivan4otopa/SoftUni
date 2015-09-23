namespace ProductsShop.Data.Migrations
{
    using ProductsShop.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using System.Xml.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductsShop.Data.ProductsShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ProductsShop.Data.ProductsShopContext";
        }

        protected override void Seed(ProductsShop.Data.ProductsShopContext context)
        {
            if (context.Users.Count() == 0)
            {
                var xmlDocument = XDocument.Load("../../users.xml");

                IEnumerable<User> users =
                    from user in xmlDocument.Descendants("user")
                    select new User
                    {
                        FirstName = user.Attribute("first-name") == null ? null : user.Attribute("first-name").Value,
                        LastName = user.Attribute("last-name").Value,
                        Age = user.Attribute("age") == null ? (int?)null : int.Parse(user.Attribute("age").Value)
                    };

                foreach (var user in users)
                {
                    context.Users.Add(new User()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Age = user.Age
                    });
                }

                context.SaveChanges();
            }

            if (context.Products.Count() == 0)
            {
                var serializer = new JavaScriptSerializer();
                string json = File.ReadAllText("../../products.json");
                List<Product> products = serializer.Deserialize<List<Product>>(json);
                var randomNumberGenerator = new Random();

                for (int i = 0; i < products.Count; i++)
                {
                    int sellerId = randomNumberGenerator.Next(1, context.Users.Count() + 1);

                    if (i % 20 == 0)
                    {
                        context.Products.Add(new Product()
                        {
                            Name = products[i].Name,
                            Price = products[i].Price,
                            SellerId = sellerId,
                            BuyerId = null
                        });
                    }
                    else
                    {
                        int buyerId = randomNumberGenerator.Next(1, context.Users.Count() + 1);

                        while (sellerId == buyerId)
                        {
                            sellerId = randomNumberGenerator.Next(1, context.Users.Count() + 1);
                            buyerId = randomNumberGenerator.Next(1, context.Users.Count() + 1);

                            if (sellerId != buyerId)
                            {
                                break;
                            }
                        }

                        context.Products.Add(new Product()
                        {
                            Name = products[i].Name,
                            Price = products[i].Price,
                            SellerId = sellerId,
                            BuyerId = buyerId
                        });
                    }
                }

                context.SaveChanges();
            }

            if (context.Categories.Count() == 0)
            {
                var serializer = new JavaScriptSerializer();
                string json = File.ReadAllText("../../categories.json");
                List<Category> categories = serializer.Deserialize<List<Category>>(json);
                var randomNumberGenerator = new Random();

                foreach (var category in categories)
                {
                    context.Categories.Add(new Category()
                    {
                        Name = category.Name
                    });
                }

                context.SaveChanges();

                var categoriesList = context.Categories.ToList();
                var products = context.Products.ToList();
                var randomNumberGeneratorForRelationship = new Random();
                int productIndex = 0;
                int categoryIndex = 0;

                for (int i = 0; i < 600; i++)
                {
                    productIndex = randomNumberGeneratorForRelationship.Next(0, products.Count);
                    categoryIndex = randomNumberGeneratorForRelationship.Next(0, categoriesList.Count);

                    categoriesList[categoryIndex].Products.Add(products[productIndex]);
                }

                context.SaveChanges();
            }
        }
    }
}
