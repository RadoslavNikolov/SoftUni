namespace TheSlum
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Characters;
    using Interfaces;

    public class Healer : Character, IHeal
    {
        private const int HealtPoints = 75;
        private const int DefPoint = 50;
        private const int HealPoints = 60;
        private const int ChRange = 6;

        public Healer(string id, int x, int y, Team team)
            : base(id, x, y, HealtPoints, DefPoint, team, ChRange)
        {
            this.HealingPoints = HealPoints;
        }

        public int HealingPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            Character target = targetsList
                .Where(t => t.IsAlive && t.Team == this.Team && t != this)
                .OrderBy(t => t.HealthPoints)
                .FirstOrDefault();

            return target;
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            this.ApplyItemEffects(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            this.RemoveItemEffects(item);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            output.Append(string.Format(", Healing: {0}", this.HealingPoints));
            return output.ToString();
        }
    }
}