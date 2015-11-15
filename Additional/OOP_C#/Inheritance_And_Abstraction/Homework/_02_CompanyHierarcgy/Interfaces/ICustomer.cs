namespace CompanyHierarcgy.Interfaces
{
    public interface ICustomer
    {
        decimal PurchaseAmmount { get; set; }
        void AddPurchasePrice(decimal purchasePrice);

        string ToString();
    }
}