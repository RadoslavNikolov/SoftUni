namespace MassEffect.GameObjects.Ships
{
    using System.Runtime.InteropServices;
    using System.Text;
    using Interfaces;
    using Locations;
    using Projectiles;

    public class Frigate : Starship
    {
        public Frigate(string name, StarSystem location) 
            : base(name, 60, 50, 30, 220, location)
        {
            this.ProjectilesFired = 0;
        }

        public int ProjectilesFired { get; private set; }

        public override IProjectile ProduceAttack()
        {
            this.ProjectilesFired++;
            return new ShieldReaver(this.Damage);
        }



        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(base.ToString());

            if (this.Health > 0)
            {
                output.Append(string.Format("\n-Projectiles fired: {0}", this.ProjectilesFired)); 
            }

            return output.ToString();
        }
    }
}