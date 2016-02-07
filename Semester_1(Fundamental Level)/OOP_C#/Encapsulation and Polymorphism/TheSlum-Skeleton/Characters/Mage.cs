namespace TheSlum
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Characters;
    using Interfaces;

    public class Mage : Character, IAttack
    {
        private const int HealtPoints = 150;
        private const int DefPoint = 50;
        private const int AttPoints = 300;
        private const int ChRange = 5;

        public Mage(string id, int x, int y, Team team)
            : base(id, x, y, HealtPoints, DefPoint, team, ChRange)
        {
            this.AttackPoints = AttPoints;
        }

        public int AttackPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            Character target = targetsList
                .LastOrDefault(t => t.IsAlive && t.Team != this.Team);

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
            base.RemoveItemEffects(item);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            output.Append(string.Format(", Attack: {0}", this.AttackPoints));
            return output.ToString();
        }
    }
}