namespace Empire.Models.Units
{
    public class Archer : Unit
    {
        private const int ArcherDamage = 7;
        private const int ArcherHealth = 25;

        public Archer() 
            : base(ArcherDamage, ArcherHealth)
        {
        }
    }
}