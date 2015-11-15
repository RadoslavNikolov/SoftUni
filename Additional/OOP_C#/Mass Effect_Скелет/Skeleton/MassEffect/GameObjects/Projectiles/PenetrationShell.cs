namespace MassEffect.GameObjects.Projectiles
{
    using Interfaces;

    public class PenetrationShell : Projectile
    {
        public PenetrationShell(int damage)
            : base(damage)
        {
        }

        public override void Hit(IStarship targetShip)
        {
            targetShip.Health -= this.Damage;
        }
    }
}