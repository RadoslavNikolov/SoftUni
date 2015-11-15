namespace Animals.Species
{
    using System;

    public class Frog : Animal
    {
        public Frog(string name, int age, Gender gender) : base(name, age, gender)
        {
        }

        public override void ProduceSoud()
        {
            Console.WriteLine("kvak-kvak");
        }

        public override string ToString()
        {
            return string.Format("I am {0}", this.GetType().Name);
        }
    }
}