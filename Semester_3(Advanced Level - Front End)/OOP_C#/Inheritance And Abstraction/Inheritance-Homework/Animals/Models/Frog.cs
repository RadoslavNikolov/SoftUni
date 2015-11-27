namespace Animals.Models
{
    using System;
    using Interfaces;

    public class Frog : Animal, ISwimmable 
    {
        public Frog(string name, float age = 0, bool isPoison = false) : base(name, age)
        {
            this.IsPoison = isPoison;
        }

        public bool IsPoison { get; private set; }

        public override void ProduceSound()
        {
            Console.WriteLine("Quack.., quuuackkkkk....");
        }

        public override string ToString()
        {
            return base.ToString() + " is poison: " + this.IsPoison;
        }

        public void Swim()
        {
            Console.WriteLine("I am: " + this.GetType() + " and i can swim");
        }
    }
}