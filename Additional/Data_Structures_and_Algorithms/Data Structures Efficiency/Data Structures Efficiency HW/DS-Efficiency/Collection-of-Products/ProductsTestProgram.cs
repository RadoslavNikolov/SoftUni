namespace Collection_of_Products
{
    using System;

    class ProductsTestProgram
    {
        static void Main()
        {
            var productsCollection = new CollectionsOfProducts();

            productsCollection.Add(new Product(1, "Stela", "Zagorka", 1.45m));
            productsCollection.Add(new Product(2, "Zagorka", "Zagorka", 1.1m));
            productsCollection.Add(new Product(3, "Tuborg", "Carlsberg", 1.35m));
            productsCollection.Add(new Product(4, "Shumensko", "Carlsberg", 1.2m));
            productsCollection.Add(new Product(5, "Pirinsko", "Carlsberg", 1.1m));
            productsCollection.Add(new Product(6, "Kamenitza", "Kamenitza", 1.1m));
            productsCollection.Add(new Product(7, "Becks", "Kamenitza", 1.25m));
            productsCollection.Add(new Product(8, "Absolut", "Absolut", 30m));
            productsCollection.Add(new Product(9, "Bushmils", "Bushmils", 24m));
            productsCollection.Add(new Product(10, "Black Bush", "Bushmils", 35m));
            productsCollection.Add(new Product(11, "Paddy", "Bushmils", 27.5m));
            productsCollection.Add(new Product(12, "Finlandia", "Finlandia", 23m));

            var supplier = productsCollection.FindBySupplierAndPrice("Bushmils", 24);
            foreach (var product in supplier)
            {
                Console.WriteLine(product);
            }

            //Remove by supplier Bushmils and price 24 with id=9
            productsCollection.Remove(9);
            supplier = productsCollection.FindBySupplierAndPrice("Bushmils", 24);

            foreach (var product in supplier)
            {
                Console.WriteLine(product);
            }

            var priceInRange = productsCollection.FindByPriceRange(2, 30);

            foreach (var product in priceInRange)
            {
                Console.WriteLine(product);
            }

            var byTitleAndPrice = productsCollection.FindByTitleAndPrice("Pirinsko", 1.1m);

            foreach (var product in byTitleAndPrice)
            {
                Console.WriteLine(product);
            }

            var supplierAndRange = productsCollection.FindBySupplierAndPriceRange("Carlsberg", 1.2m, 1.5m);

            foreach (var product in supplierAndRange)
            {
                Console.WriteLine(product);
            }
        }
    }
}
