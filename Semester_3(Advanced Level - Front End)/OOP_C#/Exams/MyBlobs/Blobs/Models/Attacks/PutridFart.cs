namespace Blobs.Models.Attacks
{
    using Inftrastructure;

    public class PutridFart : AttackAbstract
    {
        public override int ProduceAttack()
        {
            var damage = this.Unit.AttackDamage;
            this.Unit.Update();
            return damage;
        }
    }
}