namespace Blobs.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Infrastructure;
    using Models.Inftrastructure;

    public class Attack : CommandAbstract
    {
        public Attack(IList<string> parameters, IBlobsData data, IUnitFactory unitFactory) 
            : base(parameters, data, unitFactory)
        {
        }

        public override string Execute()
        {
            if (this.Parameters.Count < 2)
            {
                throw new ArgumentException(string.Format("The Command line is not complete. There is {0} command parameters instead of 2",
                    this.Parameters.Count));
            }

            var attackerName = this.Parameters[0];
            var targetName = this.Parameters[1];

            if (attackerName.ToLowerInvariant().Equals(targetName.ToLowerInvariant()))
            {
                throw new ArgumentException("Target and attacker cannot be the same");
            }

            var attacker = this.Data.GetUnit(attackerName);
            var target = this.Data.GetUnit(targetName);

            this.CheckIfIsDead(attacker);
            this.CheckIfIsDead(target);

            target.ResponseToAttack(attacker.Attack.ProduceAttack());

//#if DEBUG
//            this.Output.AppendLine(string.Format("I am {0}. And I was created successfully", this.GetType().Name));

//            if (this.Parameters != null)
//            {
//                foreach (var parameter in this.Parameters)
//                {
//                    this.Output.AppendLine(parameter);
//                }
//            }

//            return this.Output.ToString();
//#endif
            return "";
        }

        private void CheckIfIsDead(IUnit target)
        {
            if (target.Health == 0)
            {
                throw new InvalidOperationException("Dead blob cannot attack neither be attacked");
            }
        }
    }
}