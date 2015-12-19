namespace MyCapitalism.Interfaces
{
    using System.Collections.Generic;
    using Models.Interfaces;

    public interface ICapitalismData
    {
        IEnumerable<IOrganizationalUnit> Companies { get; }
        void AddCompany(IOrganizationalUnit company);
    }
}