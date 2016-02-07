namespace TheSlum.Items
{
    public class Pill : Bonus
    {
        private const int InjectonHealthBonus = 0;
        private const int InjectionDefenseBonus = 0;
        private const int InjectionAttackBonus = 100;
        private const int InjectionCountdown = 1;

        public Pill(string id) :
            base(id, InjectonHealthBonus, InjectionDefenseBonus, InjectionAttackBonus, InjectionCountdown)
        {
        }
    }
}