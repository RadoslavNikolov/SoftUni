namespace MyCapitalism.Models.Employees
{
    using Interfaces;

    public class ChiefTelephoneOfficer : EmployeeAbstract
    {
        private const decimal SalaryFactorDefault = -0.02m;

        public ChiefTelephoneOfficer(string firstName, string lastName, IOrganizationalUnit inUnit)
            : base(firstName, lastName, inUnit, SalaryFactorDefault)
        {
        }
    }
}