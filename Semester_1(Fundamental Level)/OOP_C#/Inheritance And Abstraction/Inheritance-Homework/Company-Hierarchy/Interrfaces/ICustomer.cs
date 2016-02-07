namespace Company_Hierarchy.Interrfaces
{
    public interface ICustomer
    {
        int Id { get;}

        decimal PurchaseAmount();

        int GetNumberOfCustomesProducts();
    }
}