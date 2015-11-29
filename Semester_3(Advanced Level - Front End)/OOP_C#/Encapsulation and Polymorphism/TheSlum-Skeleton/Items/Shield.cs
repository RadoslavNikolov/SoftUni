namespace TheSlum.Items
{
    public class Shield : Item
    {
        private const int ShieldHealthBosun = 0;
        private const int ShieldDefenseBonus = 50;
        private const int ShieldAttackBonus = 0;

        public Shield(string id) 
            : base(id, ShieldHealthBosun, ShieldDefenseBonus, ShieldAttackBonus)
        {
        }
    }
}