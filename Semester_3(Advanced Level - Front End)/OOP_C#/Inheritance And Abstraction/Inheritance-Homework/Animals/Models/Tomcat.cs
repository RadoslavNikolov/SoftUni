namespace Animals.Models
{
    using System;

    public class Tomcat : Cat
    {
        public Tomcat(string name, float age = 0, string breed = "Undefined breed") 
            : base(name, age, breed)
        {
            this.Gender = Gender.Male;
        }

        public Gender Gender { get; private set; }

        public override string ToString()
        {
            return base.ToString() + " and gender: " + this.Gender;
        }
    }
}