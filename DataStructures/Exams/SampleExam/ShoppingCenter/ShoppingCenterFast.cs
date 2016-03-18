namespace ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    class ShoppingCenterFast
    {
        private const string ProductAdded = "Product added";
        private const string XProductsDeleted = " products deleted";
        private const string NoProductsFound = "No products found";
        private const string IncorrectCommand = "Incorrect command";

        private readonly MultiDictionary<string, Product> productsByName =
            new MultiDictionary<string, Product>(true);
        private readonly MultiDictionary<string, Product> productsByNameAndProducer =
            new MultiDictionary<string, Product>(true);
        private readonly OrderedMultiDictionary<decimal, Product> productsByPrice =
            new OrderedMultiDictionary<decimal, Product>(true);
        private readonly MultiDictionary<string, Product> productsByProducer =
            new MultiDictionary<string, Product>(true);

        public string ProcessCommand(string command)
        {
            int indexOfFirstSpace = command.IndexOf(' ');
            string method = command.Substring(0, indexOfFirstSpace);
            string parameterValues = command.Substring(indexOfFirstSpace + 1);
            string[] parameters =
                parameterValues.Split(new char[] { ';' },
                    StringSplitOptions.RemoveEmptyEntries);

            switch (method)
            {
                case "AddProduct":
                    return AddProduct(parameters[0], parameters[1], parameters[2]);
                case "DeleteProducts":
                    if (parameters.Length == 1)
                    {
                        return DeleteProductsByProducer(parameters[0]);
                    }
                    else
                    {
                        return DeleteProductsByNameAndProducer(parameters[0], parameters[1]);
                    }
                case "FindProductsByName":
                    return FindProductsByName(parameters[0]);
                case "FindProductsByPriceRange":
                    return FindProductsByPriceRange(parameters[0], parameters[1]);
                case "FindProductsByProducer":
                    return FindProductsByProducer(parameters[0]);
                default:
                    return IncorrectCommand;
            }
        }

        private string AddProduct(string name, string price, string producer)
        {
            Product product = new Product()
            {
                Name = name,
                Price = decimal.Parse(price),
                Producer = producer
            };

            this.productsByName.Add(name, product);

            string nameAndProducerKey = this.CombineKeys(name, producer);

            this.productsByNameAndProducer.Add(nameAndProducerKey, product);
            this.productsByPrice.Add(product.Price, product);
            this.productsByProducer.Add(producer, product);

            return ProductAdded;
        }

        private string CombineKeys(string name, string producer)
        {
            string key = name + ";" + producer;

            return key;
        }

        private string FindProductsByName(string name)
        {
            var productsFound = this.productsByName[name];

            return SortAndPrintProducts(productsFound);
        }

        private string SortAndPrintProducts(IEnumerable<Product> products)
        {
            if (products.Any())
            {
                var sortedProducts = new List<Product>(products);

                sortedProducts.Sort();

                var builder = new StringBuilder();

                foreach (var product in sortedProducts)
                {
                    builder.AppendLine(product.ToString());
                }

                builder.Length -= Environment.NewLine.Length;

                string formattedProducts = builder.ToString();

                return formattedProducts;
            }

            return NoProductsFound;
        }

        private string FindProductsByProducer(string producer)
        {
            var productsFount = this.productsByProducer[producer];

            return SortAndPrintProducts(productsFount);
        }

        private string FindProductsByPriceRange(string from, string to)
        {
            decimal rangeStart = decimal.Parse(from);
            decimal rangeEnd = decimal.Parse(to);
            var productsFound = this.productsByPrice.Range(rangeStart, true, rangeEnd, true).Values;

            return SortAndPrintProducts(productsFound);
        }

        private string DeleteProductsByNameAndProducer(string name, string producer)
        {
            string nameAndProducerKey = name + ";" + producer;
            var productsToBeRemoved = this.productsByNameAndProducer[nameAndProducerKey];

            if (productsToBeRemoved.Any())
            {
                int countOfRemovedProducts = productsToBeRemoved.Count;

                foreach (var product in productsToBeRemoved)
                {
                    this.productsByName.Remove(product.Name, product);
                    this.productsByProducer.Remove(product.Producer, product);
                    this.productsByPrice.Remove(product.Price, product);
                }

                this.productsByNameAndProducer.Remove(nameAndProducerKey);

                return countOfRemovedProducts + XProductsDeleted;
            }

            return NoProductsFound;
        }

        private string DeleteProductsByProducer(string producer)
        {
            var productsToBeRemoved = this.productsByProducer[producer];

            if (productsToBeRemoved.Any())
            {
                foreach (var product in productsToBeRemoved)
                {
                    this.productsByName.Remove(product.Name, product);

                    string nameAndProducerKey = this.CombineKeys(product.Name, producer);

                    this.productsByNameAndProducer.Remove(nameAndProducerKey, product);
                    this.productsByPrice.Remove(product.Price, product);
                }

                int countOfRemovedProducts = this.productsByProducer[producer].Count;

                this.productsByProducer.Remove(producer);

                return countOfRemovedProducts + XProductsDeleted;
            }

            return NoProductsFound;
        }
    }
}
