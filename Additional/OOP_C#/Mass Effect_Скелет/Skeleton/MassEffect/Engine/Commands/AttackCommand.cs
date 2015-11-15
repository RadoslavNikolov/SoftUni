namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;
    using MassEffect.Interfaces;

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string attackerName = commandArgs[1];
            string targetName = commandArgs[2];

            IStarship attackingShip = null, targetShip = null;
            attackingShip = this.GameEngine.Starships.FirstOrDefault(s => s.Name == attackerName);
            targetShip = this.GameEngine.Starships.FirstOrDefault(s => s.Name == targetName);

            this.ProcessStarshipBattle(attackingShip, targetShip);

        }

        private void ProcessStarshipBattle(IStarship attackingShip, IStarship targetShip)
        {
            base.ValidateAlive(attackingShip);
            base.ValidateAlive(targetShip);

            if (attackingShip.Location.Name != targetShip.Location.Name)
            {
                throw new ArgumentException("Ships are in different star systems!");
            }

            IProjectile attack = attackingShip.ProduceAttack();
            targetShip.RespondToAttack(attack);

            Console.WriteLine(Messages.ShipAttacked, attackingShip.Name, targetShip.Name);

            if (targetShip.Shields < 0)
            {
                targetShip.Shields = 0;
            }

            if (targetShip.Health <= 0)
            {
                targetShip.Health = 0;
                Console.WriteLine(Messages.ShipDestroyed, targetShip.Name);
            }


        }

        
    }
}
