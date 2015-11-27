namespace Company_Hierarchy.Models
{
    public abstract class RegularEmployee : Employee
    {
        protected RegularEmployee(string firstName, string lastName, decimal salary, string department) 
            : base(firstName, lastName, salary, department)
        {
        }
    }
}