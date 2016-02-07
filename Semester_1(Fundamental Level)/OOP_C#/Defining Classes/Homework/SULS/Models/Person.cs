namespace SULS.Models
{
    using System;
    using System.Text;
    using Interfaces;

    public class Person
    {
        public string firstName;
        public string lastName;
        public int age;

        public Person(string fristName, string lastName, int age)
        {
            this.FristName = fristName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FristName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name cannot be null or empty!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last name cannot be null!");
                }

                this.lastName = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("Age must be in range [0-120]");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            var result = $"Role: {this.GetType().Name}\n";
            result += $"First Name: {this.FristName}\n";
            result += $"Last Name: {this.LastName}\n";
            result += $"Age: {this.Age}\n";

            return result;
        }
    }
}