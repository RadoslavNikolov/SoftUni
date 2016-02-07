namespace Persons
{
    using System;
    using System.Text.RegularExpressions;

    public class Person
    {
        private string name;
        private int age;
        private string email;

        public Person(string name, int age)
            :this(name, age, null)
        {
        }

        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name cannot be null!");
                }

                if (value.Trim() == "")
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            private set
            {
                if (value < 1 || value > 100 )
                {
                    throw new ArgumentOutOfRangeException("Age must be in range [1-100]");
                }

                this.age = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (value != null)
                {
                    bool isEmail = Regex.IsMatch(value, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

                    if (!isEmail)
                    {
                        throw new ArgumentException("Entered email is not valid email", nameof(value));
                    }

                    this.email = value;
                }
            }
        }

        public override string ToString()
        {
            return $"Name: {this.Name},  Age: {this.Age},  Email: {this.Email ?? "Not defined!"}";
        }

        public void Print()
        {
            var result = $"Name: {this.Name},  Age: {this.Age},  Email: {this.Email ?? "Not defined!"}";
            Console.WriteLine(result);
        }
    }
}