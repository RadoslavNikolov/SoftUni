namespace Human_Worker_Student.Models
{
    using Helpers;

    public abstract class Human
    {
        private string firstName;
        private string lastName;

        protected Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                CustomValidators.ValidateName(value);
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                CustomValidators.ValidateName(value);
                this.lastName = value;
            }
        }
    }
}