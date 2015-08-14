namespace ShopSystem.Console
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Data;
    using Model;
    using System.Web.Script.Serialization;
    using Newtonsoft.Json;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new ShopEntities();

            ////Problem 2
            //ImportUserFromXml(context);
            //ImportCategoriesFromJSON(context);
            //ImportProductsFromJSON(context);

            ////Problem3
            //// Query1
            //GenerateJSONQuery1(context);
            ////Query2
            //GenerateJSONQuery2(context);

            ////Query3
            //GenerateJSONQuery3(context);


            //Query4
            var users = context.Users
                .Where(u => u.SoldProduct.Any() &&
                    u.SoldProduct.Where(p => p.Buyer != null).Count() > 0)
                .OrderByDescending(u => u.SoldProduct.Count)
                .ThenBy(u => u.LastName)
                .Select(u => new
                {
                    firstName = u.FirstName ?? "-",
                    lastName = u.LastName,
                    age = u.Age,
                    products = u.SoldProduct.Select(p => new
                    {
                        name = p.Name,
                        price = p.Price
                    })
                }).ToList();

            var xml = new XDocument();
            var root  = new XElement("users");
            root.SetAttributeValue("count", users.Count);

            foreach (var user in users)
            {
                var userNode = new XElement("user");
                if (user.firstName != null)
                {
                    userNode.SetAttributeValue("first-name", user.firstName);
                }

                if (user.lastName != null)
                {
                    userNode.SetAttributeValue("last-name", user.lastName);
                }

                if (user.age != null)
                {
                    userNode.SetAttributeValue("age", user.age);
                }

                var productsNode = new XElement("sold-products");
                productsNode.SetAttributeValue("count", user.products.Count());
                foreach (var product in user.products)
                {
                    var productNode = new XElement("product");
                    productNode.SetAttributeValue("name", product.name);
                    productNode.SetAttributeValue("price", product.price);

                    productsNode.Add(productNode);
                }

                userNode.Add(productsNode);
                root.Add(userNode);
            }
            xml.Add(root);
            xml.Save(@"../../../users-and-products.xml");
            Console.WriteLine(File.ReadAllText(@"../../../users-and-products.xml"));
        }




        private static void GenerateJSONQuery3(ShopEntities context)
        {
            var categories = context.Categories
                .Select(p => new
                {
                    category = p.Name,
                    productsCount = p.Products.Count,
                    averagePrice = p.Products.Average(s => s.Price),
                    totalRevenue = p.Products.Sum(s => s.Price)
                }).OrderBy(p => p.productsCount).ToList();

            var beautifulJson = JsonConvert.SerializeObject(categories, Formatting.Indented);
            File.WriteAllText(@"../../../categories-by-products.json", beautifulJson);
            //Console.WriteLine(beautifulJson);
        }

        private static void GenerateJSONQuery2(ShopEntities context)
        {
            var users = context.Users
                .Where(u => u.SoldProduct.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(s => new
                {
                    firstName = s.FirstName ?? "-",
                    lastName = s.LastName,
                    soldProducts = s.SoldProduct
                    .Where(sp => sp.BuyerId != null)
                    .Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    })
                }).ToList();

            var beautifulJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(@"../../../users-sold-products.json", beautifulJson);
            //Console.WriteLine(beautifulJson);
        }


        private static void GenerateJSONQuery1(ShopEntities context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000 && p.BuyerId == null)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                }).OrderBy(p => p.price).ToList();

            var json = JsonConvert.SerializeObject(products);
            var beautifulJson = JsonConvert.SerializeObject(products, Formatting.Indented);

            File.WriteAllText(@"../../../products-in-range.json", beautifulJson);
            //Console.WriteLine(beautifulJson);
        }


        private static void ImportProductsFromJSON(ShopEntities context)
        {
            var json = File.ReadAllText(@"../../../products.json");
            var jsonProducts = JsonConvert.DeserializeObject<List<Product>>(json);
            Random rnd = new Random();
            foreach (var product in jsonProducts)
            {
                int[] userId = GetRandomUserId(context);
                var currProduct = new Product()
                {
                    Name = product.Name,
                    Price = product.Price,
                    Seller = context.Users.Find(userId[0]),
                    Categories = new List<Category>()
                    {
                        context.Categories.Find(GetRandomCategoryId(context))
                    }
                };

                if (rnd.Next(0,10) != 0)
                {
                    currProduct.Buyer = context.Users.Find(userId[1]);
                }

                context.Products.AddOrUpdate(currProduct);
                
            }

            context.SaveChanges();


            foreach (var product in context.Products.ToList())
            {
                Console.WriteLine(product.Name);
                //product.Categories.Add(new Category
                //{
                //    Name = "Drugs"
                //});
                //context.SaveChanges();
                //Console.WriteLine(product.Categories.Count);

            }


            foreach (var product in jsonProducts)
            {
                string.Join(", ", product.Categories);
                context.SaveChanges();
            }
        }

        private static int GetRandomCategoryId(ShopEntities context)
        {
            var categoryIds = context.Categories.Select(c => c.Id).ToList();
            Random rnd = new Random();
            Console.WriteLine(rnd.Next(categoryIds.Count));

            int categoryId = categoryIds[rnd.Next(0, categoryIds.Count)];
            return categoryId;
        }

        private static int[] GetRandomUserId(ShopEntities context)
        {
            var usersIds = context.Users.Select(u => u.Id).ToList();
            Random rnd = new Random();
            int selerId = usersIds[rnd.Next(0, usersIds.Count)];
            int bueyerId = selerId;
            int[] ids = new int[2];

            while (selerId == bueyerId)
            {
                bueyerId = usersIds[rnd.Next(0,usersIds.Count)];
            }         

            ids[0] = selerId;
            ids[1] = bueyerId;

            return ids;
        }

        private static void ImportCategoriesFromJSON(ShopEntities context)
        {
            var json = File.ReadAllText("../../../categories.json");
            var categories = JsonConvert.DeserializeObject<List<Category>>(json);
            foreach (var category in categories)
            {
                if (category.Name != null)
                {
                    context.Categories.AddOrUpdate(category);
                }
                context.SaveChanges();
            }
        }

        private static void ImportUserFromXml(ShopEntities context)
        {
            XDocument doc = XDocument.Load("../../../users.xml");
            var users =
                from u in doc.Descendants("user")
                select new
                {
                    FirstName = u.Attribute("first-name") != null ? u.Attribute("first-name").Value : null,
                    LastName = u.Attribute("last-name") != null ? u.Attribute("last-name").Value : null,
                    Age = u.Attribute("age") != null ? u.Attribute("age").Value : null
                };

            foreach (var user in users)
            {
                context.Users.AddOrUpdate(u => new
                {
                    u.FirstName,
                    u.LastName
                },
                    new User()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Age = Convert.ToInt32(user.Age)
                    });
            }
            context.SaveChanges();
        }
    }
}
