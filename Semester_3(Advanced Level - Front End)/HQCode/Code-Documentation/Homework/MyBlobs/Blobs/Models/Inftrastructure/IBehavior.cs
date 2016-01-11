namespace Blobs.Models.Inftrastructure
{
    using System.Net.Configuration;
    using System.Runtime;
    using Infrastructure;

    public interface IBehavior : IUpdatable
    {
        IUnit Unit { get; set; }

        bool IsTriggered { get; set; }

        void TriggerBehavior();
    }
}