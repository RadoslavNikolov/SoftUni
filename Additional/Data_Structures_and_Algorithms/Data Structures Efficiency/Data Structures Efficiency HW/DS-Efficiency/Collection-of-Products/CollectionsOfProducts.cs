namespace Collection_of_Products
{
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class CollectionsOfProducts
    {
        private readonly Dictionary<int, Product> productsById;
        private readonly OrderedMultiDictionary<string, Product> productByTitleAndPrice;
        private readonly OrderedMultiDictionary<decimal, Product> productsByPrice;
        private readonly OrderedMultiDictionary<string, Product> productsByTitle;
        private readonly OrderedDictionary<string, OrderedMultiDictionary<decimal, Product>> productByTitleAndPriceRange;
        private readonly OrderedMultiDictionary<string, Product> productBySupplierAndPrice;
        private readonly OrderedDictionary<string, OrderedMultiDictionary<decimal, Product>> productBySupplierAndPriceRange;

        public CollectionsOfProducts()
        {
            this.productByTitleAndPrice = new OrderedMultiDictionary<string, Product>(true);
            this.productsById = new Dictionary<int, Product>();
            this.productsByPrice = new OrderedMultiDictionary<decimal, Product>(true);
            this.productsByTitle = new OrderedMultiDictionary<string, Product>(true);
            this.productByTitleAndPriceRange = new OrderedDictionary<string, OrderedMultiDictionary<decimal, Product>>();
            this.productBySupplierAndPrice = new OrderedMultiDictionary<string, Product>(true);
            this.productBySupplierAndPriceRange = new OrderedDictionary<string, OrderedMultiDictionary<decimal, Product>>();
        }

        public void Add(Product product)
        {
            this.productsById.Add(product.Id, product);
            this.productsByPrice.Add(product.Price, product);
            this.productsByTitle.Add(product.Title, product);
            this.productByTitleAndPrice.Add(product.Title + '_' + product.Price, product);

            if (!this.productByTitleAndPriceRange.ContainsKey(product.Title))
            {
                this.productByTitleAndPriceRange.Add(product.Title, new OrderedMultiDictionary<decimal, Product>(true));
            }
            this.productByTitleAndPriceRange[product.Title][product.Price].Add(product);

            this.productBySupplierAndPrice.Add(product.Supplier + '_' + product.Price, product);

            if (!this.productBySupplierAndPriceRange.ContainsKey(product.Supplier))
            {
                this.productBySupplierAndPriceRange.Add(product.Supplier, new OrderedMultiDictionary<decimal, Product>(true));
            }
            this.productBySupplierAndPriceRange[product.Supplier][product.Price].Add(product);
        }


        public void Remove(int id)
        {
            var product = this.productsById[id];

            this.productsByPrice.Remove(product.Price, product);
            this.productsByTitle.Remove(product.Title, product);
            this.productByTitleAndPrice.Remove(product.Title + '_' + product.Price, product);

            this.productByTitleAndPriceRange[product.Title].Remove(product.Price, product);
            if (this.productByTitleAndPriceRange[product.Title].Count == 0)
            {
                this.productByTitleAndPriceRange.Remove(product.Title);
            }

            this.productBySupplierAndPrice.Remove(product.Supplier + '_' + product.Price, product);

            this.productBySupplierAndPriceRange[product.Supplier].Remove(product.Price, product);
            if (this.productBySupplierAndPriceRange[product.Supplier].Count == 0)
            {
                this.productByTitleAndPriceRange.Remove(product.Supplier);
            }
        }

        public OrderedMultiDictionary<decimal, Product>.View FindByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return this.productsByPrice.Range(minPrice, true, maxPrice, true);
        }

        public IEnumerable<Product> FindByTitle(string title)
        {
            return this.productsByTitle[title];
        }

        public IEnumerable<Product> FindByTitleAndPrice(string title, decimal price)
        {
            return this.productByTitleAndPrice[title + '_' + price];
        }

        public OrderedMultiDictionary<decimal, Product>.View FindByTitleAndPriceRange(string title, decimal minPrice,
            decimal maxPrice)
        {
            return this.productByTitleAndPriceRange[title].Range(minPrice, true, maxPrice, true);
        }

        public IEnumerable<Product> FindBySupplierAndPrice(string supplier, decimal price)
        {
            return this.productBySupplierAndPrice[supplier + '_' + price];
        }

        public OrderedMultiDictionary<decimal, Product>.View FindBySupplierAndPriceRange(string supplier, decimal minPrice,
           decimal maxPrice)
        {
            return this.productBySupplierAndPriceRange[supplier].Range(minPrice, true, maxPrice, true);
        }
    }
}