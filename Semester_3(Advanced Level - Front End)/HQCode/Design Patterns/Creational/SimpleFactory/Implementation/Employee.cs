namespace SimpleFactory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Employee
    {
        public decimal Salary { get; set; }

        public Employee(decimal salary = 200m)
        {
            this.Salary = salary;
        }
    }
}
