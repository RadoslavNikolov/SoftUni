namespace TheSlum.Items
{
    public class Injection : Bonus
    {
        private const int InjectonHealthBonus = 200;
        private const int InjectionDefenseBonus = 0;
        private const int InjectionAttackBonus = 0;
        private const int InjectionCountdown = 3;

        public Injection(string id) 
            : base(id, InjectonHealthBonus, InjectionDefenseBonus, InjectionAttackBonus, InjectionCountdown)
        {
        }
    }
}