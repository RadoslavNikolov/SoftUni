namespace Orders.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Interfaces;
    using Models;

    public class DataCommonTools : IData
    {
        public Order GetOrderById(int orderId)
        {
            var order = Database.Orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null)
            {
                throw new InvalidOperationException(string.Format("There is no order with id: {0}", orderId));
            }

            return order;
        }

        public IEnumerable<Order> GetOrdersByProductId(int productId)
        {
            var resultOrders = Database.Orders.Where(o => o.Product.Id == productId);
            if (resultOrders == null)
            {
                throw new InvalidOperationException(string.Format("There is no orders with product id: {0}", productId));
            }

            return resultOrders;
        }

        public IEnumerable<Order> GetOrdersByProductName(string productName)
        {
            var resultOrders = Database.Orders.Where(o => o.Product.Name.ToLowerInvariant() == productName);
            if (resultOrders == null)
            {
                throw new InvalidOperationException(string.Format("There is no orders with product name: {0}", productName));
            }

            return resultOrders;
        }

        public bool AddOrder(Order order)
        {
            if (Database.Orders.Any(o => o.Id == order.Id ))
            {
                throw new InvalidOperationException("Order cannot be add. There is already order with this id");
            }

            Database.Orders.Add(order);

            return true;
        }

        public bool RemoveOrderById(int orderId)
        {
            var order = this.GetOrderById(orderId);
            if (order == null)
            {
                throw new InvalidOperationException(string.Format("There is nothing to remove. No order with id: {0}", orderId));
            }

            return this.RemoveOrder(order);
        }

        public bool RemoveOrder(Order order)
        {
            if (!Database.Orders.Contains(order))
            {
                throw new InvalidOperationException("There is nothing to remove. No such order");
            }

            Database.Orders.Remove(order);

            return true;
        }

        public Category GetCategoryById(int catId)
        {
            var category = Database.Categories.FirstOrDefault(c => c.Id == catId);
            if (category == null)
            {
                throw new InvalidOperationException(string.Format("There is no category with id: {0}", catId));
            }

            return category;
        }

        public Category GetCategoryByName(string catName)
        {
            var category = Database.Categories.FirstOrDefault(c => String.Equals(c.Name, catName, StringComparison.InvariantCultureIgnoreCase));
            if (category == null)
            {
                throw new InvalidOperationException(string.Format("There is no category with name: {0}", catName));
            }

            return category;
        }

        public bool AddCategoty(Category category)
        {
            if (Database.Categories.Any(c => c.Id == category.Id || String.Equals(c.Name, category.Name, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new InvalidOperationException("Category cannot be add. There is already category with this id or this name");
            }

            Database.Categories.Add(category);

            return true;
        }

        public bool RemoveCategoryById(int catId)
        {
            var category = this.GetCategoryById(catId);
            if (category == null)
            {
                throw new InvalidOperationException(string.Format("There is nothing to remove. No category with id: {0}", catId));
            }
           
            return this.RemoveCategory(category);
        }

        public bool RemoveCategory(Category category)
        {
            if (!Database.Categories.Contains(category))
            {
                throw new InvalidOperationException("There is nothing to remove. No such category");
            }

            Database.Categories.Remove(category);

            return true;
        }

        public Product GetProductById(int productId)
        {
            var product = Database.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                throw new InvalidOperationException(string.Format("There is no product with id: {0}", productId));
            }

            return product;
        }

        public Product GetProductByName(string productName)
        {
            var product = Database.Products.FirstOrDefault(p => String.Equals(p.Name, productName, StringComparison.InvariantCultureIgnoreCase));
            if (product == null)
            {
                throw new InvalidOperationException(string.Format("There is no product with name: {0}", productName));
            }

            return product;
        }

        public bool AddProduct(Product product)
        {
            if (Database.Products.Any(p => p.Id == product.Id || String.Equals(p.Name, product.Name, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new InvalidOperationException("Product cannot be add. There is already product with this id or this name");
            }

            Database.Products.Add(product);

            return true;
        }

        public bool RemoveProductById(int productId)
        {
            var product = this.GetProductById(productId);
            if (product == null)
            {
                throw new InvalidOperationException(string.Format("There is nothing to remove. No product with id: {0}", productId));
            }

            return this.RemoveProduct(product);
        }

        public bool RemoveProduct(Product product)
        {
            if (!Database.Products.Contains(product))
            {
                throw new InvalidOperationException("There is nothing to remove. No such product");
            }

            Database.Products.Remove(product);

            return true;
        }      
    }
}