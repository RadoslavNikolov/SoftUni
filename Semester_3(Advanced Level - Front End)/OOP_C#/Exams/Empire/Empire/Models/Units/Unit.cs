namespace Empire.Models.Units
{
    using System;
    using Interfaces;

    public abstract class Unit : IUnit
    {
        private int attackDamage;
        private int health;

        protected Unit(int attackDamage, int health)
        {
            this.AttackDamage = attackDamage;
            this.Health = health;
        }

        public int AttackDamage
        {
            get { return this.attackDamage; }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Attack damage cannot be negative");
                }

                this.attackDamage = value;
            }
        }

        public int Health
        {
            get { return this.health; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Health damage cannot be negative");
                }

                this.health = value;
                this.health = this.health < 0 ? 0 : this.health;
            }
        }
    }
}