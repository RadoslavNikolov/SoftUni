namespace MyCapitalism.Models.Employees
{
    using Interfaces;

    public class CleaningLady : EmployeeAbstract
    {
        private const decimal SalaryFactorDefault = -0.02m;

        public CleaningLady(string firstName, string lastName, IOrganizationalUnit inUnit)
            : base(firstName, lastName, inUnit, SalaryFactorDefault)
        {
        }
    }
}