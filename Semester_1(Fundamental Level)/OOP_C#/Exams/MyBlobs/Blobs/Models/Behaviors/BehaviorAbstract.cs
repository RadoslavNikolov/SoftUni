namespace Blobs.Models.Behaviors
{
    using Inftrastructure;

    public abstract class BehaviorAbstract : IBehavior
    {
        public IUnit Unit { get; set; }

        public bool IsTriggered { get; set; }

        public abstract void TriggerBehavior();

        public abstract void Update();
    }
}