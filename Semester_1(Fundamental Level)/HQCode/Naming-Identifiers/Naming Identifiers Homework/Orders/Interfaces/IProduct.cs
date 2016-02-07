namespace Orders.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface IProduct
    {
        Product GetProductById(int productId);

        Product GetProductByName(string productName);

        bool AddProduct(Product product);

        bool RemoveProductById(int productId);

        bool RemoveProduct(Product product);
    }
}