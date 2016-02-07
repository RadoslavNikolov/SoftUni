using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Orders
{
    using Data;
    using Models;

    class ProcessOrdersProgram
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            // Names of the 5 most expensive products
            var mostExpensiveProdicts = Database.Products
                .OrderByDescending(p => p.UnitPrice)
                .Take(5)
                .Select(p => p.Name);
            Console.WriteLine(string.Join(Environment.NewLine, mostExpensiveProdicts));

            Console.WriteLine(new string('-', 10));

            // Number of products in each category
            var numProductsByCategory = Database.Products
                .GroupBy(p => p.Category)
                .Select(grp => new { Category = grp.Key.Name, ProductCount = grp.Count() })
                .ToList();

            //var numProductsByCategory =
            //    from p in Database.Products
            //    group p by p.Category
            //    into g
            //    select new {Category = g.Key.Name, ProductCount = g.Count()};

            foreach (var item in numProductsByCategory)
            {
                Console.WriteLine("{0}: {1}", item.Category, item.ProductCount);
            }

            Console.WriteLine(new string('-', 10));

            // The 5 top products (by order quantity)
            var productsOrdByQty = Database.Orders
                .GroupBy(o => o.ProductId)
                .Select(group1 => new { Product = Database.Products.First(p => p.Id == group1.Key).Name, Quantities = group1.Sum(group2 => group2.Quantity) })
                .OrderByDescending(q => q.Quantities)
                .Take(5);
            foreach (var item in productsOrdByQty)
            {
                Console.WriteLine("{0}: {1}", item.Product, item.Quantities);
            }

            Console.WriteLine(new string('-', 10));

            // The most profitable category
            var mostProfitCatagory = Database.Orders
                .GroupBy(o => o.ProductId)
                .Select(g => new { catId = Database.Products.First(p => p.Id == g.Key).CatId, price = Database.Products.First(p => p.Id == g.Key).UnitPrice, quantity = g.Sum(p => p.Quantity) })
                .GroupBy(group => group.catId)
                .Select(grp => new { category_name = Database.Categories.First(c => c.Id == grp.Key).Name, total_quantity = grp.Sum(g => g.quantity * g.price) })
                .OrderByDescending(g => g.total_quantity)
                .First();
            Console.WriteLine("{0}: {1}", mostProfitCatagory.category_name, mostProfitCatagory.total_quantity);
        }
    }
}
