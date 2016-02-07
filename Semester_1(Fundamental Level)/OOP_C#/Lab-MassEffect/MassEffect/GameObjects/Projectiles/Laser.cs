namespace MassEffect.GameObjects.Projectiles
{
    using Interfaces;

    public class Laser : Projectile
    {
        public Laser(int damage) 
            : base(damage)
        {
        }

        public override void Hit(IStarship ship)
        {
            if (this.Damage > ship.Shields)
            {
                ship.Health -= (this.Damage - ship.Shields);
                ship.Shields = 0;
                
            }
            else
            {
                ship.Shields -= this.Damage;
            }

            
        }
    }
}