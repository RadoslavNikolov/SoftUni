namespace Abstract_Exercise_Game.Characters
{
    using Interfaces;
    public class Priest : Character, IHeal
    {
        public Priest() 
            : base(125, 200, 100)
        {
        }

        public override void Attack(Character target)
        {
            target.Health -= this.Damage;
            this.Health += (this.Damage/10);
        }

        public void Heal(Character target)
        {
            target.Health += 150;
            this.Mana -= 100;
        }
    }
}