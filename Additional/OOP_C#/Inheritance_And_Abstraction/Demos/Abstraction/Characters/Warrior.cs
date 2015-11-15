namespace Abstraction.Characters
{
    public class Warrior : Character
    {
        public Warrior() : base(300, 0, 120)
        {
        }

        public override void Attack(Character target)
        {
            //this.Mana -= 100;
            target.Health -= 2 * this.Damage;
        }
    }
}