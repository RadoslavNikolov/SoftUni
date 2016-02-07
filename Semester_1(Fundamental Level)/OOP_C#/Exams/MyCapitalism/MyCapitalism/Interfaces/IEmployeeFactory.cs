namespace MyCapitalism.Interfaces
{
    using Models.Interfaces;

    public interface IEmployeeFactory
    {
        IEmployee Create(string employeeType, object[] parameters);
    }
}