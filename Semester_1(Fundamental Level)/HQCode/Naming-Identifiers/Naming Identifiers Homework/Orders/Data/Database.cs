namespace Orders.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using Models;

    public static class Database
    {
        private const string CategoriesFileName = "../../Data/Resources/categories.txt";
        private const string ProductsFileName = "../../Data/Resources/products.txt";
        private const string OrdersFileName = "../../Data/Resources/orders.txt";

        static Database()
        {
            Categories = new List<Category>();
            Products = new List<Product>();
            Orders = new List<Order>();
            DataTools = new DataCommonTools();
            InitCategories();
            InitProducts();
            InitOrders();
        }

        public static ICollection<Category> Categories { get; set; }

        public static ICollection<Product> Products { get; set; }

        public static ICollection<Order> Orders { get; set; }

        public static DataCommonTools DataTools { get; set; }

        public static void InitCategories()
        {
            var fileLines = ReadFileLines(CategoriesFileName, true);
            var categories = fileLines
                .Select(c => c.Split(','))
                .Select(c => new Category(int.Parse(c[0]), c[1], c[2]));

            foreach (var category in categories)
            {
                try
                {
                    DataTools.AddCategoty(category);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void InitProducts()
        {
            var fileLines = ReadFileLines(ProductsFileName, true);
            var products = fileLines
                .Select(p => p.Split(','))
                .Select(p => new Product(int.Parse(p[0]), p[1], int.Parse(p[2]), decimal.Parse(p[3]), int.Parse(p[4])));

            foreach (var product in products)
            {
                try
                {
                    DataTools.AddProduct(product);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void InitOrders()
        {
            var fileLines = ReadFileLines(OrdersFileName, true);
            var orders = fileLines
                .Select(o => o.Split(','))
                .Select(o => new Order(int.Parse(o[0]), int.Parse(o[1]), int.Parse(o[2]), decimal.Parse(o[3])));

            foreach (var order in orders)
            {
                try
                {
                    DataTools.AddOrder(order);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static IEnumerable<string> ReadFileLines(string filename, bool hasHeader)
        {
            var allLines = new List<string>();
            using (var reader = new StreamReader(filename))
            {
                string currentLine;
                if (hasHeader)
                {
                    reader.ReadLine();
                }

                while ((currentLine = reader.ReadLine()) != null)
                {
                    allLines.Add(currentLine);
                }
            }

            return allLines;
        }
    }
}