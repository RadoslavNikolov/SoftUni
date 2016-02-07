namespace MyCapitalism.Models.Interfaces
{
    using System.Collections.Generic;

    public interface IEmployee
    {
        string FirstName { get; }
        string LastName { get; }
        IOrganizationalUnit InUnit { get; set; }
        decimal SalaryFactor { get; }
        decimal TotalPaid { get; set; }
        decimal RecieveSalary(decimal percents, decimal ceoSalary);
    }
}