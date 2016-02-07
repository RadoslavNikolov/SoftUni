namespace MyCapitalism.Models.Employees
{
    using Interfaces;

    public class Manager : EmployeeAbstract
    {
        private const decimal SalaryFactorDefault = 0;

        public Manager(string firstName, string lastName, IOrganizationalUnit inUnit)
            : base(firstName, lastName, inUnit, SalaryFactorDefault)
        {
        }
    }
}