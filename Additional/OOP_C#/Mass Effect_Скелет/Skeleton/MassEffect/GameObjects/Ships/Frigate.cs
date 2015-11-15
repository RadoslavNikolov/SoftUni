namespace MassEffect.GameObjects.Ships
{
    using System.Collections.Generic;
    using System.Text;
    using Enhancements;
    using Interfaces;
    using Locations;
    using Projectiles;

    public class Frigate : Starship
    {
        public Frigate(string name, StarSystem location)
            : base(name, 60, 50, 30, 220, location)
        {
            ProjectilesFired = 0;
        }

        public int ProjectilesFired { get; private set; }

        public override IProjectile ProduceAttack()
        {
            this.ProjectilesFired++;
            return new ShieldReaver(this.Damage);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());

            if (this.Health > 0)
            {
                result.Append(string.Format("\n-Projectiles fired: {0}", this.ProjectilesFired)); 
            }

            return result.ToString();
        }
    }
}