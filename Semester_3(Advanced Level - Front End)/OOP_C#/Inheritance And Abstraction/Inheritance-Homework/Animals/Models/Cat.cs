namespace Animals.Models
{
    using System;
    using Interfaces;

    public class Cat : Animal, IRunable
    {
        public Cat(string name, float age = 0, string breed = "Undefined breed") 
            : base(name, age)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }

        public override void ProduceSound()
        {
            Console.WriteLine("Miauuuuuu......");
        }

        public void Run()
        {
            Console.WriteLine("I am: " + this.GetType() + " and i can run like flash light");
        }

        public override string ToString()
        {
            return base.ToString() + " and breed: " + this.Breed;
        }
    }
}