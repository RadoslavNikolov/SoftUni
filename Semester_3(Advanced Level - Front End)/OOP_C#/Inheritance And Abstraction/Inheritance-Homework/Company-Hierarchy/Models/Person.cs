namespace Company_Hierarchy.Models
{
    using System;
    using Human_Worker_Student.Helpers;
    using Interrfaces;

    public abstract class Person : IPerson
    {
        private static int _id = 0;
        private string firstName;
        private string lastName ;

        protected Person(string firstName, string lastName)
        {
            Person._id++;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = Person._id;
        }

        public int Id { get; private set; }

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

        public override string ToString()
        {
            return String.Format("Type: {0} / Id: {1} / First name: {2} / Last name: {3}", 
                this.GetType().Name,this.Id, this.FirstName, this.LastName);
        }
    }
}