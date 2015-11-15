namespace MassEffect.GameObjects.Projectiles
{
    using Interfaces;

    public class Laser : Projectile
    {
        public Laser(int damage)
            : base(damage)
        {
        }

        public override void Hit(IStarship targetShip)
        {
            if (this.Damage > targetShip.Shields)
            {
                int leftDamage = this.Damage - targetShip.Shields;
                targetShip.Health -= leftDamage;
                targetShip.Shields -= this.Damage;
            }
            else
            {
                targetShip.Shields -= this.Damage;
            }
        }
    }
}