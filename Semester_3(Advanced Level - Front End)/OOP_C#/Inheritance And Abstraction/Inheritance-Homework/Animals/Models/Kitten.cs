namespace Animals.Models
{
    using System;

    public class Kitten : Cat
    {
        public Kitten(string name, float age = 0f, string breed = "Undefined breed") 
            : base(name, age,breed)
        {
            this.Gender = Gender.Female;
        }

        public Gender Gender { get; private set; }

        public override string ToString()
        {
            return base.ToString() + " and gender: " + this.Gender;
        }
    }
}