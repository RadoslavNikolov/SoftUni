namespace TheSlum.Items
{
    public class Axe : Item
    {
        private const int AxeHealthBosun = 0;
        private const int AxeDefenseBonus = 0;
        private const int AxeAttackBonus = 75;

        public Axe(string id) : 
            base(id, AxeHealthBosun, AxeDefenseBonus, AxeAttackBonus)
        {
        }
    }
}