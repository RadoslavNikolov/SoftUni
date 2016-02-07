namespace MyCapitalism.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Factories;
    using Interfaces;
    using Models.Interfaces;
    using Models.OrganizationalUnits;

    public class CreateCompany : CommandAbstract
    {
        private readonly string companyName;
        private readonly string ceoFirstName;
        private readonly string ceoLastName;
        private readonly decimal ceoSalary;

        public CreateCompany(IList<string> parameters, ICapitalismData data) 
            : base(parameters, data)
        {
            this.companyName = this.Parameters[0];
            this.ceoFirstName = this.Parameters[1];
            this.ceoLastName = this.Parameters[2];
            this.ceoSalary = decimal.Parse(this.Parameters[3]);
        }

        public override string Execute()
        {

            foreach (IOrganizationalUnit c
                in this.Data.Companies)
            {
                if (c.Name == this.companyName)
                {
                    throw new Exception(string.Format("Company {0} already exists", this.companyName));
                }
            }

            IOrganizationalUnit company = new Company(this.companyName);
            IEmployee ceo = EmployeeFactory.Create(this.ceoFirstName, this.ceoLastName, "CEO", company, this.ceoSalary);
            this.Data.AddCompany(company);
            company.AddEmployee(ceo);
            company.Head = ceo;
            return "";
        }
    }
}