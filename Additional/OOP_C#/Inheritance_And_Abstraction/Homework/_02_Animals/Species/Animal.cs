namespace Animals.Species
{
    using System;
    using Interfaces;

    public abstract class Animal : ISoundProducible
    {
        private string name;
        private int age;

        protected Animal(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        protected string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty!");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0 || value > 50)
                {
                    throw new ArgumentOutOfRangeException("Age must be in range [0...50]");
                }
                this.age = value;
            }
        }

        protected Gender Gender { get; set; }

        public abstract void ProduceSoud();
    }
}