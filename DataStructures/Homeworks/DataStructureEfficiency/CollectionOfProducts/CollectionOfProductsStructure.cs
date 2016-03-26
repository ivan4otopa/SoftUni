namespace CollectionOfProducts
{
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    class CollectionOfProductsStructure
    {
        Dictionary<int, Product> productsById = new Dictionary<int, Product>();
        OrderedDictionary<decimal, SortedSet<Product>> productsByPrice =
            new OrderedDictionary<decimal, SortedSet<Product>>();
        Dictionary<string, SortedSet<Product>> productsByTitle =
            new Dictionary<string, SortedSet<Product>>();
        Dictionary<string, SortedSet<Product>> productsByTitleAndPrice =
            new Dictionary<string, SortedSet<Product>>();
        Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>> orderedProductsByTitleAndPrice =
            new Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>>();
        Dictionary<string, SortedSet<Product>> productsBySupplierAndPrice =
            new Dictionary<string, SortedSet<Product>>();
        Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>> orderedProductsBySupplierAndPriceRange =
            new Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>>();

        public void Add(string title, string supplier, decimal price)
        {
            var product = new Product(title, supplier, price);

            this.productsById.Add(product.Id, product);            

            if (!this.productsByPrice.ContainsKey(price))
            {
                this.productsByPrice[price] = new SortedSet<Product>();
            }
            
            this.productsByPrice[price].Add(product);

            if (!this.productsByTitle.ContainsKey(title))
            {
                this.productsByTitle[title] = new SortedSet<Product>();
            }

            this.productsByTitle[title].Add(product);

            string titleAndPriceKey = this.CombineTitleAndPriceKeys(title, price);

            if (!this.productsByTitleAndPrice.ContainsKey(titleAndPriceKey))
            {
                this.productsByTitleAndPrice[titleAndPriceKey] = new SortedSet<Product>();
            }

            this.productsByTitleAndPrice[titleAndPriceKey].Add(product);

            string supplierAndPriceKey = this.CombineSupplierAndPriceKeys(supplier, price);

            if (!this.productsBySupplierAndPrice.ContainsKey(supplierAndPriceKey))
            {
                this.productsBySupplierAndPrice[supplierAndPriceKey] = new SortedSet<Product>();
            }

            this.productsBySupplierAndPrice[supplierAndPriceKey].Add(product);

            if (!this.orderedProductsByTitleAndPrice.ContainsKey(title))
            {
                this.orderedProductsByTitleAndPrice[title] = new OrderedDictionary<decimal, SortedSet<Product>>();                
            }

            if (!this.orderedProductsByTitleAndPrice[title].ContainsKey(price))
            {
                this.orderedProductsByTitleAndPrice[title][price] = new SortedSet<Product>();
            }

            this.orderedProductsByTitleAndPrice[title][price].Add(product);

            if (!this.orderedProductsBySupplierAndPriceRange.ContainsKey(supplier))
            {
                this.orderedProductsBySupplierAndPriceRange[supplier] = new OrderedDictionary<decimal, SortedSet<Product>>();                
            }

            if (!this.orderedProductsBySupplierAndPriceRange[supplier].ContainsKey(price))
            {
                this.orderedProductsBySupplierAndPriceRange[supplier][price] = new SortedSet<Product>();
            }

            this.orderedProductsBySupplierAndPriceRange[supplier][price].Add(product);
        }

        public bool Remove(int id)
        {
            var product = this.Find(id);

            if (product == null)
            {
                return false;
            }

            this.productsById.Remove(id);
            this.productsByPrice[product.Price].Remove(product);
            this.productsByTitle[product.Title].Remove(product);

            string titleAndPriceKey = this.CombineTitleAndPriceKeys(product.Title, product.Price);

            this.productsByTitleAndPrice[titleAndPriceKey].Remove(product);

            string supplierAndPriceKey = this.CombineSupplierAndPriceKeys(product.Supplier, product.Price);

            this.productsBySupplierAndPrice[supplierAndPriceKey].Remove(product);
            this.orderedProductsByTitleAndPrice[product.Title][product.Price].Remove(product);
            this.orderedProductsBySupplierAndPriceRange[product.Supplier][product.Price].Remove(product);

            return true;
        }

        public IEnumerable<Product> FindProducts(decimal start, decimal end)
        {
            var productsInRange = this.productsByPrice.Range(start, true, end, true);

            foreach (var productsByPrice in productsInRange)
            {
                foreach (var product in productsByPrice.Value)
                {
                    yield return product;
                }
            }
        }

        public IEnumerable<Product> FindProducts(string title)
        {
            if (!this.productsByTitle.ContainsKey(title))
            {
                yield break;
            }

            foreach (var product in productsByTitle[title])
            {
                yield return product;
            }
        }

        public IEnumerable<Product> FindProductsByTitleAndPrice(string title, decimal price)
        {
            var titleAndPriceKey = this.CombineTitleAndPriceKeys(title, price);

            if (!this.productsByTitleAndPrice.ContainsKey(titleAndPriceKey))
            {
                yield break;
            }

            foreach (var product in this.productsByTitleAndPrice[titleAndPriceKey])
            {
                yield return product;
            }
        }

        public IEnumerable<Product> FindProductsByTitleAndPriceRange(string title, decimal start, decimal end)
        {
            if (!this.orderedProductsByTitleAndPrice.ContainsKey(title))
            {
                yield break;
            }

            var productsInRange = this.orderedProductsByTitleAndPrice[title].Range(start, true, end, true);

            foreach (var productInRange in productsInRange)
            {
                foreach (var product in productInRange.Value)
                {
                    yield return product;
                }
            }
        }

        public IEnumerable<Product> FindProductsBySupplierAndPrice(string supplier, decimal price)
        {
            var supplierAndPriceKey = this.CombineSupplierAndPriceKeys(supplier, price);

            if (!this.productsBySupplierAndPrice.ContainsKey(supplierAndPriceKey))
            {
                yield break;
            }

            foreach (var product in this.productsBySupplierAndPrice[supplierAndPriceKey])
            {
                yield return product;
            }
        }

        public IEnumerable<Product> FindProductsBySupplierAndPriceRange(string supplier, decimal start, decimal end)
        {
            if (!this.orderedProductsBySupplierAndPriceRange.ContainsKey(supplier))
            {
                yield break;
            }

            var productsInRange = this.orderedProductsBySupplierAndPriceRange[supplier].Range(start, true, end, true);

            foreach (var productsBySupplierAndPriceRange in productsInRange)
            {
                foreach (var product in productsBySupplierAndPriceRange.Value)
                {
                    yield return product;
                }
            }
        }

        private string CombineTitleAndPriceKeys(string title, decimal price)
        {
            return string.Format("{0} {1}", title, price);
        }

        private string CombineSupplierAndPriceKeys(string supplier, decimal price)
        {
            return string.Format("{0} {1}", supplier, price);
        }

        private Product Find(int id)
        {
            return this.productsById[id];           
        }
    }
}
