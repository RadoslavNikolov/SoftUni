namespace Orders.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface IData : ICategory, IProduct, IOrder
    {
    }
}