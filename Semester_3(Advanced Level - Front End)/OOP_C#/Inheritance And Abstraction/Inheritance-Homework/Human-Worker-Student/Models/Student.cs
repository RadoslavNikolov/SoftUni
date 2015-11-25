namespace Human_Worker_Student.Models
{
    using System;
    using Helpers;

    public class Student : Human, IComparable<Student>
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber) 
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {
                CustomValidators.ValidateFacultyNum(value);
                this.facultyNumber = value.ToUpperInvariant();
            }
        }

        public int CompareTo(Student other)
        {
            return String.Compare(this.FacultyNumber, other.FacultyNumber, StringComparison.InvariantCultureIgnoreCase);
        }

        public override string ToString()
        {
            return String.Format("Type: {0}  /  First Name: {1}  /  Last Name: {2}  /  FacNum: {3}",
                this.GetType().Name, this.FirstName, this.LastName, this.FacultyNumber);
        }
    }
}