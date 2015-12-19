namespace Empire.Models.Units
{
    public class Swordsman : Unit
    {
        private const int SwordsmanDamage = 13;
        private const int SwordsmanHealth = 40;


        public Swordsman() 
            : base(SwordsmanDamage, SwordsmanHealth)
        {
        }
    }
}