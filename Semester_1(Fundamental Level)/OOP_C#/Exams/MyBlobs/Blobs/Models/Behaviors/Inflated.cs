namespace Blobs.Models.Behaviors
{
    using System;
    using Inftrastructure;

    public class Inflated : BehaviorAbstract
    {
        private const int HealthBonus = 50;
        public override void TriggerBehavior()
        {
            if (this.IsTriggered)
            {
                return;
            }

            this.IsTriggered = true;
            this.Unit.Health += HealthBonus;
        }

        public override void Update()
        {
            if (this.IsTriggered)
            {
                this.Unit.Health -= 10;              
            }
        }
    }
}