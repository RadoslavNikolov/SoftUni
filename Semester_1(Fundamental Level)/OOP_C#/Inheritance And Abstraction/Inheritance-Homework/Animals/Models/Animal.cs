namespace Animals.Models
{
    using System;
    using Interfaces;

    public abstract class Animal : ISoundProducible
    {
        private float age;

        protected Animal(string name = "Unnamed", float age = 0f)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }

        public float Age
        {
            get { return this.age; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Age must be in range [0 - 100]");
                }

                this.age = value;
            }
        }

        public abstract void ProduceSound();

        public override string ToString()
        {
            return String.Format("Animal type: {0}  with  name:  {1}  age: {2}",
                this.GetType().Name, this.Name, this.Age);
        }
    }
}