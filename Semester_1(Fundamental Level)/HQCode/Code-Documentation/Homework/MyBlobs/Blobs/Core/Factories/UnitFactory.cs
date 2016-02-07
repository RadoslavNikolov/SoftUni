namespace Blobs.Core.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Infrastructure;
    using Models.Inftrastructure;

    public class UnitFactory : IUnitFactory
    {
        private readonly IBehaviorFactory behaviorFactory;
        private readonly IAttackFactory attackFactory;

        //For this logic is fine. We have todreate only one unit
        const string UnitType = "Blob";

        public UnitFactory(IBehaviorFactory behaviorFactory, IAttackFactory attackFactory)
        {
            this.behaviorFactory = behaviorFactory;
            this.attackFactory = attackFactory;
        }

        public IUnit CreateUnit(IList<string> parameters)
        {          
            if (parameters.Count < 5)
            {
                throw new ArgumentException(string.Format("The Command line is not complete. There is {0} command parameters instead of 5",
                    parameters.Count));
            }

            var name = parameters[0];
            int initialHealth;
            int initialAttackDamage;

            var success = int.TryParse(parameters[1], out initialHealth);
            if (!success)
            {
                throw new ArgumentException("Blob`s initial health must be valid number");
            }

            success = int.TryParse(parameters[2], out initialAttackDamage);
            if (!success)
            {
                throw new ArgumentException("Blob`s initial attack damage must be valid number");
            }

            IBehavior behavor = this.behaviorFactory.CreateBehavior(parameters[3]);
            IAttack attack = this.attackFactory.CreateAttack(parameters[4]);

            Type type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name.ToLowerInvariant() == UnitType.ToLowerInvariant());

            //not necessary for now
            if (type == null)
            {
                throw new ArgumentException("Unknown unit type");
            }

            var unit = (IUnit)Activator.CreateInstance(type, name, initialHealth, initialAttackDamage, behavor, attack);
            unit.Behavior.Unit = unit;
            unit.Attack.Unit = unit;

            return unit;
        }
    }
}