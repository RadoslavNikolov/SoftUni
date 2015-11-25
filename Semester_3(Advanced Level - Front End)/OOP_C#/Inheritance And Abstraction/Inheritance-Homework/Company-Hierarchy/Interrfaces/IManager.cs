namespace Company_Hierarchy.Interrfaces
{
    using System.Collections.Generic;

    public interface IManager
    {
        ICollection<IEmployee> Employees { get; set; }

        bool DeleteSale(int saledId);

        bool DeleteProduct(int productId);

        bool CloseProjectById(int id);
    }
}