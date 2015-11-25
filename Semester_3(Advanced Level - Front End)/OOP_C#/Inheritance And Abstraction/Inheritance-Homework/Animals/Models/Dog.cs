namespace Animals.Models
{
    using System;

    public class Dog : Animal
    {
        public Dog(string name,float age = 0, string breеd = "Undefined breed") : base(name, age)
        {
            this.Breеd = breеd;
        }

        public string Breеd { get; private set; }

        public override void ProduceSound()
        {
            Console.WriteLine("Bauu, bauu, bauuuu...");
        }

        public override string ToString()
        {
            return base.ToString() + " and breed: " + this.Breеd;
        }
    }
}