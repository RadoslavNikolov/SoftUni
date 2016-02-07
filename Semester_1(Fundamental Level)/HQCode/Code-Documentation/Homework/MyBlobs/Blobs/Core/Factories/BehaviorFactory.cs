namespace Blobs.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Infrastructure;
    using Models.Inftrastructure;

    public class BehaviorFactory : IBehaviorFactory
    {
        public IBehavior CreateBehavior(string behaviorType)
        {

            Type type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name.ToLowerInvariant() == behaviorType.ToLowerInvariant());

            if (type == null)
            {
                throw new ArgumentException("Unknown behavior type");
            }

            var behavior = (IBehavior)Activator.CreateInstance(type);

            return behavior;
        }
    }
}