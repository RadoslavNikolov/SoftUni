namespace Company_Hierarchy.Interrfaces
{
    using System.Collections.Generic;

    public interface ISale
    {
        int Id { get;}

        int CustomerId { get; set; }

        int SalesManID { get; set; }

        ICollection<IProduct> Products { get; set; }

        decimal GetSaleTotalPrice();
    }
}