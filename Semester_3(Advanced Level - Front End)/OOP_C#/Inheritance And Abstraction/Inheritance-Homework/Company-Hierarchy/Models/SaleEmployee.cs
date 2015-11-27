namespace Company_Hierarchy.Models
{
    using System.Collections.Generic;
    using Interrfaces;

    public class SaleEmployee : RegularEmployee, ISaleEmployee
    {
        private ICollection<ISale> sales;
 
        public SaleEmployee(string firstName, string lastName, decimal salary, string department) 
            : base(firstName, lastName, salary, department)
        {
            this.sales = new HashSet<ISale>();
        }

        public virtual ICollection<ISale> Sales
        {
            get { return this.sales; }
            set { this.sales = value; }
        }
    }
}