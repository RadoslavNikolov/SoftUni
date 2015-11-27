namespace Human_Worker_Student.Models
{
    using System;
    using Helpers;

    public class Worker : Human, IComparable<Worker>
    {
        private decimal workSalary;
        private float workHoursPerDay;

        public Worker(string firstName, string lastName, decimal workSalary = 420m, float workHoursPerDay = 8f) 
            : base(firstName, lastName)
        {
            this.WorkSalary = workSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WorkSalary
        {
            get { return this.workSalary; }
            set
            {
                CustomValidators.ValidateNumber(value);
                this.workSalary = value;
            }
        }

        public float WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set
            {
                CustomValidators.ValidateNumber((decimal)value);
                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            return this.WorkSalary/(decimal) this.WorkHoursPerDay;
        }

        public int CompareTo(Worker other)
        {
            return this.MoneyPerHour().CompareTo(other.MoneyPerHour());
        }

        public override string ToString()
        {
            return String.Format("Type: {0}  /  First Name: {1}  /  Last Name: {2}  /  WeekSalary: {3:N2}  /  WorkHoursPerDay: {4:N2}  /  MoneyPerHour: {5:N2}",
                this.GetType().Name, this.FirstName, this.LastName, this.WorkSalary, this.WorkHoursPerDay, this.MoneyPerHour());
        }
    }
}