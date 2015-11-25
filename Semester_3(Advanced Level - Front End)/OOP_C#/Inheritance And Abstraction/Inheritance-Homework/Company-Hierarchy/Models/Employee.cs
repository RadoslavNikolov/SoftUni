namespace Company_Hierarchy.Models
{
    using System;
    using System.Globalization;
    using System.Text;
    using Human_Worker_Student.Helpers;
    using Interrfaces;

    public abstract class Employee : Person, IEmployee
    {
        private decimal salary;
        private Departments department;

        protected Employee(string firstName, string lastName, decimal salary, string department) 
            : base(firstName, lastName)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                CustomValidators.ValidateNumber(value);
                this.salary = value;
            }
        }

        public string Department
        {
            get { return this.department.ToString(); }
            set
            {
                try
                {
                    this.department = (Departments) Enum.Parse(typeof (Departments),
                        CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower()));
                }
                catch (Exception)
                {

                    Console.WriteLine("There is no such department");
                }
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder().AppendLine(base.ToString());
            output.AppendLine(String.Format("Department: {0} / Salary: {1:N2}", this.Department.ToString(), this.Salary));
            return output.ToString();
        }
    }
}