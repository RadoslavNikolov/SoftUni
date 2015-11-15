namespace Animals.Species
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age) : base(name, age, Species.Gender.Female)
        {
        }

        public override string ToString()
        {
            return string.Format("I am {0}", this.GetType().Name);
        }
    }


}