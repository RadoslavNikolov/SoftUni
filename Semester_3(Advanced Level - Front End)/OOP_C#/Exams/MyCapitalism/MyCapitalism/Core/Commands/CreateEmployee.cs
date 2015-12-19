namespace MyCapitalism.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Factories;
    using Interfaces;
    using Models.Interfaces;
    using Models.OrganizationalUnits;

    public class CreateEmployee : CommandAbstract
    {
        private string firstName;
        private string lastName;
        private string position;
        private string companyName;
        private string departmentName;



        public CreateEmployee(IList<string> parameters, ICapitalismData data) 
            : base(parameters, data)
        {
            this.firstName = this.Parameters[0];
            this.lastName = this.Parameters[1];
            this.position = this.Parameters[2];
            this.companyName = this.Parameters[3];

            this.departmentName = this.Parameters.Count >= 5 ? this.Parameters[4] : null;
        }

        public override string Execute()
        {
            Company company = this.Data.Companies.Cast<Company>().FirstOrDefault(c => c.Name == this.companyName);

            if (company == null)
            {
                throw new ArgumentException(
                    string.Format("Company {0} does not exist", this.companyName));
            }

            foreach (IEmployee e in company.AllEmployees)
            {
                if (e.FirstName == this.firstName && e.LastName == this.lastName)
                {
                    if (e.InUnit is Company)
                    {
                        throw new ArgumentException(
                            string.Format(
                                "Employee {0} {1} already exists in {2} (no department)",
                                this.firstName,
                                this.lastName,
                                this.companyName
                                ));
                    }
                    else
                    {
                        throw new ArgumentException(
                           string.Format(
                               "Employee {0} {1} already exists in {2} (in department {3})",
                               this.firstName,
                               this.lastName,
                               this.companyName,
                               e.InUnit.Name
                               ));
                    }
                }
            }

            IOrganizationalUnit inUnit = company;
            if (this.departmentName != null)
            {
                foreach (IOrganizationalUnit d in company.AllDepartments)
                {
                    if (d.Name == this.departmentName)
                    {
                        inUnit = d;
                        break;
                    }
                }
            }

            IEmployee employee = EmployeeFactory.Create(
                this.firstName,
                this.lastName,
                this.position,
                inUnit
                );

            company.AllEmployees.Add(employee);
            inUnit.AddEmployee(employee);
            return "";
        }
    }
}