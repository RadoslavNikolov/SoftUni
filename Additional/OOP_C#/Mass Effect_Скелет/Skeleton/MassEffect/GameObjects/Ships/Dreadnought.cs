namespace MassEffect.GameObjects.Ships
{
    using System.Collections.Generic;
    using Enhancements;
    using Interfaces;
    using Locations;
    using Projectiles;

    public class Dreadnought : Starship
    {
        public Dreadnought(string name, StarSystem location)
            : base(name, 200, 300, 150, 700, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            return new Laser(this.Damage + this.Shields / 2);
        }

        public override void RespondToAttack(IProjectile projectile)
        {
            this.Shields += 50;

            base.RespondToAttack(projectile);

            this.Shields -= 50;

        }
    }
}