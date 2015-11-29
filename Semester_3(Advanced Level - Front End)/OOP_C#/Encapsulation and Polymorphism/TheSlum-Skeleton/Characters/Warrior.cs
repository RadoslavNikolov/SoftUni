namespace TheSlum
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Characters;
    using Interfaces;

    public class Warrior : Character, IAttack
    {
        private const int HealtPoints = 200;
        private const int DefPoint = 100;
        private const int AttPoints = 150;
        private const int ChRange = 2;

        public Warrior(string id, int x, int y, Team team) 
            : base(id, x, y, HealtPoints, DefPoint, team, ChRange)
        {
            this.AttackPoints = AttPoints;
        }

        public int AttackPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            Character target = targetsList
                .Where(t => t.IsAlive && t.Team != this.Team)
                .OrderByDescending(t => t.HealthPoints)
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

        protected override void ApplyItemEffects(Item item)
        {
            this.AttackPoints += item.AttackEffect;
            base.ApplyItemEffects(item);
        }

        protected override void RemoveItemEffects(Item item)
        {
            this.AttackPoints -= item.AttackEffect;
            base.ApplyItemEffects(item);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            output.Append(string.Format(", Attack: {0}", this.AttackPoints));
            return output.ToString();
        }
    }
}