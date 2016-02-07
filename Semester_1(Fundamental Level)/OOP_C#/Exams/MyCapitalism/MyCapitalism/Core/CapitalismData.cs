namespace MyCapitalism.Core
{
    using System.Collections.Generic;
    using Interfaces;
    using Models.Interfaces;

    public class CapitalismData : ICapitalismData
    {
        private readonly IList<IOrganizationalUnit> companies;

        public CapitalismData()
        {
            this.companies = new List<IOrganizationalUnit>();
        }

        public IEnumerable<IOrganizationalUnit> Companies
        {
            get { return this.companies; }
        }

        public void AddCompany(IOrganizationalUnit company)
        {
            this.companies.Add(company);
        }
    }
}