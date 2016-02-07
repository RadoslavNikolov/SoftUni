namespace MyCapitalism.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interfaces;
    using Models.Employees;
    using Models.Interfaces;

    public class PaySalaries : CommandAbstract
    {
        private readonly string companyName;
        private CEO ceo;
        private StringBuilder output = new StringBuilder();

        public PaySalaries(IList<string> parameters, ICapitalismData data) 
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
            ceo = (CEO)company.Head;
            this.Pay(company, 0, 0);
            return this.output.ToString();
        }

        private decimal Pay(
            IOrganizationalUnit unit,
            decimal paid,
            int depth)
        {

            foreach (var dep in unit.SubUnits)
            {
                paid += this.Pay(dep, 0, depth + 1);
            }

            foreach (var emp in unit.Employees)
            {
                decimal percents = (15 - depth) * 0.01m;
                paid += emp.RecieveSalary(percents, this.ceo.Salary);
            }

            this.output.Insert(0,
                    string.Format("{0}{1} ({2:f2})\n",
                        new String(' ', depth * 4),
                        unit.Name,
                        paid
                        )
                    );

            return paid;
        }
    }
}