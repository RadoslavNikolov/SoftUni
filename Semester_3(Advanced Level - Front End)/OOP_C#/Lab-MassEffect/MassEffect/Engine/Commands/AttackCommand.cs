namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;
    using Exceptions;
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

            IStarship attackingShip = this.GameEngine.Starships.FirstOrDefault(s => s.Name == attackerName);
            IStarship targetShip = this.GameEngine.Starships.FirstOrDefault(s => s.Name == targetName);

            if (attackerName == null || targetShip == null)
            {
                throw new ShipException("Attacker ship name or target ship name is incorrect");
            }

            this.ProcessStarshipBattle(attackingShip, targetShip);
        }

        private void ProcessStarshipBattle(IStarship attackingShip, IStarship targetShip)
        {

            this.ValidateAlive(attackingShip);
            this.ValidateAlive(targetShip);

            if (attackingShip.Location.Name != targetShip.Location.Name)
            {
                throw new LocationOutOfRangeException("Ships are in different star systems");
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
