namespace MyCapitalism.Models.Interfaces
{
    using System.Collections.Generic;

    public interface IOrganizationalUnit
    {
        string Name { get; }
        IEnumerable<IOrganizationalUnit> SubUnits { get; }
        IEnumerable<IEmployee> Employees { get; }
        IEmployee Head { get; set; }
        void AddSubUnit(IOrganizationalUnit unit);
        void AddEmployee(IEmployee employee);
        void RemoveEmployee(IEmployee employee);
    }
}