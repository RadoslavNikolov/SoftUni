namespace Orders.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface IOrder
    {
        Order GetOrderById(int orderId);

        IEnumerable<Order> GetOrdersByProductId(int productId);

        IEnumerable<Order> GetOrdersByProductName(string productName);

        bool AddOrder(Order order);

        bool RemoveOrderById(int orderId);

        bool RemoveOrder(Order order);
    }
}