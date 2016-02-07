namespace Blobs.Models.Units
{
    using System;
    using Inftrastructure;

    public class Blob : IUnit
    {
        private int attackDamage;
        private int health;
        private string name;
        private int initialHealth;
        private int initialDamage;

        public Blob(string name, int health, int attackDamage, IBehavior behavior, IAttack attack)
        {
            this.Name = name;
            this.Health = health;
            this.AttackDamage = attackDamage;
            this.InitialHeallth = health;
            this.InitialDamage = attackDamage;
            this.Behavior = behavior;
            this.Attack = attack;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Blob name cannot be null or empty");
                }
                this.name = value;
            }
        }

        public int Health
        {
            get { return this.health; }
            set
            {
                this.health = value;
                this.health = this.health < 0 ? 0 : this.health;
            }
        }

        public int InitialHeallth
        {
            get { return this.initialHealth; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Health cannot be negative");
                }

                this.initialHealth = value;
            }
        }

        public int AttackDamage
        {
            get { return this.attackDamage; }
            set
            {
                this.attackDamage = value;
                this.attackDamage = this.attackDamage < 0 ? 0 : this.attackDamage;
            }
        }

        public int InitialDamage
        {
            get { return this.initialDamage; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Damage cannot be negative");
                }

                this.initialDamage = value;
            }
        }

        public IBehavior Behavior { get; private set; }

        public IAttack Attack { get; private set; }

        public void Update()
        {         
            if (!this.Behavior.IsTriggered)
            {
                if (this.Health <= this.InitialHeallth / 2)
                {
                    this.Behavior.TriggerBehavior();
                }
            }
            else
            {
                this.Behavior.Update();
            }
        }

        public void ResponseToAttack(int damage)
        {
            this.Health -= damage;
            this.Update();
        }

        public override string ToString()
        {
            var output = "";
            if (this.Health == 0)
            {
                output += string.Format("Blob {0} KILLED", this.Name);
                return output;
            }

            output = string.Format("Blob {0}: {1} HP, {2} Damage",
                this.Name, this.Health, this.AttackDamage);

//#if DEBUG
//            output += string.Format("Behavior type: {0} /  Attack type: {1}", this.Behavior.GetType().Name,
//                this.Attack.GetType().Name);
//#endif
            
            return output;
        }
    }
}