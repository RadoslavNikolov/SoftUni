using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_SULS
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw  new ArgumentOutOfRangeException("Age cannot be negative!");
                }
                this.age = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name cannot be empty!");
                }
                this.lastName = value;
            }
        }


        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw  new ArgumentException("First name cannot be empty!");
                }
                this.firstName = value;
            }
        }

        public override string ToString()
        {
            string result = string.Format("First name: {0}\nLast name: {1}\nAge: {2}\n",this.FirstName,this.LastName,this.Age);
            return result;
        }
    }
}
