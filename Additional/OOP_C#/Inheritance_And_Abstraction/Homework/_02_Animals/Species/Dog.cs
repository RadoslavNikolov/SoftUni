namespace Animals.Species
{
    using System;

    public class Dog : Animal
    {
        public Dog(string name, int age, Gender gender) : base(name, age, gender)
        {
        }

        public override void ProduceSoud()
        {
            Console.WriteLine("bau-bauuuuuu");
        }

        public override string ToString()
        {
            return string.Format("I am {0}", this.GetType().Name);
        }
    }
}