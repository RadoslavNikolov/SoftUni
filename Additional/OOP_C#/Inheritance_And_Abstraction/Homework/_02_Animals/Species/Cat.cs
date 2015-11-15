namespace Animals.Species
{
    using System;

    public abstract class Cat : Animal
    {
        protected Cat(string name, int age, Gender gender) : base(name, age, gender)
        {
        }

        public override void ProduceSoud()
        {
            Console.WriteLine("Miauuuuuuuu");
        }

        public override string ToString()
        {
            return string.Format("I am {0}", this.GetType().Name);
        }
    }
}