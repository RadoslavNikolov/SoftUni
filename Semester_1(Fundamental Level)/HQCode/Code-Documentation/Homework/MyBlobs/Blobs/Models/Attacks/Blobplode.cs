namespace Blobs.Models.Attacks
{
    using Inftrastructure;

    public class Blobplode : AttackAbstract
    {
        public override int ProduceAttack()
        {
            this.Unit.Health -= (this.Unit.Health/2);
            this.Unit.Health = this.Unit.Health < 1 ? 1 : this.Unit.Health;

            this.Unit.Update();
            int damage = this.Unit.AttackDamage*2;
         
            return damage;
        }
    }
}