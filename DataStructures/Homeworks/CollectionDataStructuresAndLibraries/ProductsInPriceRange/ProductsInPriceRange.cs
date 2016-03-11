namespace ProductsInPriceRange
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Wintellect.PowerCollections;

    class ProductsInPriceRange
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var products = new OrderedMultiDictionary<double, string>(true);
            int numberOfLines = int.Parse(Console.ReadLine());
            string line = string.Empty;
            string productName = string.Empty;
            double productPrice = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                line = Console.ReadLine();

                var parts = line.Split(' ');

                productName = parts[0].Trim();
                productPrice = double.Parse(parts[1].Trim());

                products.Add(productPrice, productName);
            }

            var limits = Console.ReadLine().Split(' ');
            double lowerLimit = double.Parse(limits[0].Trim());
            double upperLimit = double.Parse(limits[1].Trim());
            var productsInRange = products.Range(lowerLimit, true, upperLimit, true);

            foreach (var productInRange in productsInRange)
            {
                Console.WriteLine("{0} {1}", productInRange.Key, productInRange.Value);
            }
        }
    }
}
