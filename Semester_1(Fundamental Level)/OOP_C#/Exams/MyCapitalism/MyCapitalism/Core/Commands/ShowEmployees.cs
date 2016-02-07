namespace MyCapitalism.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interfaces;
    using Models.Employees;
    using Models.Interfaces;

    public class ShowEmployees : CommandAbstract
    {
        private readonly string companyName;
        private CEO ceo;
        private readonly StringBuilder output = new StringBuilder();

        public ShowEmployees(IList<string> parameters, ICapitalismData data) 
            : base(parameters, data)
        {
            this.companyName = parameters[0];
        }

        public override string Execute()
        {
            IOrganizationalUnit company = this.Data.Companies.FirstOrDefault(c => c.Name == this.companyName);
            if (company == null)
            {
                throw new ArgumentException(
                    string.Format("Company {0} does not exist", this.companyName));
            }
            this.ceo = (CEO)company.Head;

            return this.PrintHierarchy(company, 0);
        }

        private string PrintHierarchy(IOrganizationalUnit unit, int depth)
        {
            this.output.AppendLine(string.Format("{0}({1})", new String(' ', depth*4), unit.Name));

            foreach (IEmployee employee in unit.Employees)
            {
                this.output.AppendLine(string.Format("{0}{1} {2} ({3:f2})", new String(' ', depth * 4), employee.FirstName, employee.LastName, employee.TotalPaid));
            }

            foreach (IOrganizationalUnit subUnit in unit.SubUnits)
            {
                this.PrintHierarchy(subUnit, depth + 1);
            }

            return this.output.ToString();
        }
    }
}