using System;
using FootballLeague.Helpers;

namespace FootballLeague.Models
{
    public class Player
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private decimal salary;

        public Player(string firstName, string lastName, DateTime dateOfBirth, decimal salary, Team playerTeam)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Salary = salary;
            this.PlayerTeam = playerTeam;
        }

        public string  FirstName
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

        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                CustomValidators.ValidateNumber((int)value);
                this.salary = value;
            }
        }

        public DateTime DateOfBirth
        {
            get { return this.dateOfBirth; }
            set
            {
                CustomValidators.ValidateDate(value);
                this.dateOfBirth = value;
            }
        }

        public Team PlayerTeam { get; set; }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}