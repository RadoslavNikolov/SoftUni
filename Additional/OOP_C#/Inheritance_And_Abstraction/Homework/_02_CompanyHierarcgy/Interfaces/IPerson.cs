namespace CompanyHierarcgy.Interfaces
{
    public interface IPerson
    {
        string ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string ToString();
    }
}