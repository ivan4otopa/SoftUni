namespace CollectionOfProducts
{
    using System;

    class CollectionOfProductsMain
    {
        static void Main()
        {
            var structure = new CollectionOfProductsStructure();

            structure.Add("Oriz", "OrizMakers", 9.99M);
            structure.Add("Domati", "DomatiMakers", 8.33M);
            structure.Add("Krastavici", "KrastaviciMakers", 7.22M);
            structure.Add("Praskovi", "PraskoviMakers", 6.77M);
            structure.Add("Fasul", "FasulMakers", 3.15M);
            structure.Add("Qgodi", "OrizMakers", 4.25M);
            structure.Add("Bob", "DomatiMakers", 2.25M);
            structure.Add("Kartofi", "KrastaviciMakers", 5.16M);
            structure.Add("Bob", "PraskoviMakers", 2.25M);
            structure.Add("Bob", "FasulMakers", 14.99M);

            var productsByPrice = structure.FindProducts(4.25M, 7.22M);

            Console.WriteLine(
                "Products in price range 4.25 -> 7.22:\n{0}",
                string.Join("\n", productsByPrice));

            var productsByTitle = structure.FindProducts("Bob");

            Console.WriteLine(
                "Products with title bob: \n{0}",
                string.Join("\n", productsByTitle));

            var productsByTitleAndPrice = structure.FindProductsByTitleAndPrice("Kartofi", 5.16M);

            Console.WriteLine(
                "Products with title Kartofi and price 5.16:\n{0}",
                string.Join("\n", productsByTitleAndPrice));

            var productsBySupplierAndPrice = structure.FindProductsBySupplierAndPrice("KrastaviciMakers", 5.16M);

            Console.WriteLine(
                "Products by supplier KrastaviciMakers and price 5.16:\n{0}",
                string.Join("\n", productsBySupplierAndPrice));

            var productsByTitleInPriceRange = structure.FindProductsByTitleAndPriceRange("Bob", 2.25M, 14.99M);

            Console.WriteLine(
                "Products with name Bob in price range 2.25 -> 14.99:\n{0}",
                string.Join("\n", productsByTitleInPriceRange));

            var productsBySupplierInPriceRange = structure.FindProductsBySupplierAndPriceRange("DomatiMakers", 4.25M, 9M);

            Console.WriteLine(
                "Products with supplier DomatiMakers in price range 4.25 -> 9:\n{0}",
                string.Join("\n", productsBySupplierInPriceRange));
        }
    }
}
