namespace Blobs.Models.Behaviors
{
    using System;
    using Inftrastructure;

    public class Aggressive : BehaviorAbstract
    {
        public override void TriggerBehavior()
        {
            if (this.IsTriggered)
            {
                return;
            }

            this.Unit.Behavior.IsTriggered = true;
            this.Unit.InitialDamage = this.Unit.AttackDamage;
            this.Unit.AttackDamage = this.Unit.AttackDamage * 2;
        }

        public override void Update()
        {
            if (!this.IsTriggered)
            {
                return;
            }

            if (this.Unit.AttackDamage > this.Unit.InitialDamage)
            {
                this.Unit.AttackDamage -= 5;
            }

            this.Unit.AttackDamage = this.Unit.AttackDamage < this.Unit.InitialDamage ? this.Unit.InitialDamage : this.Unit.AttackDamage;
        }
    }
}