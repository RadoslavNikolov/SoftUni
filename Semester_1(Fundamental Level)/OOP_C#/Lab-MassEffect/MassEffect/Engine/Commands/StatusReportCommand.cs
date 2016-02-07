namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;
    using Exceptions;
    using MassEffect.Interfaces;

    public class StatusReportCommand : Command
    {
        public StatusReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string shipName = commandArgs[1];
            IStarship ship = this.GameEngine.Starships.FirstOrDefault(s => s.Name == shipName);

            if (ship == null)
            {
                throw new ShipException("Ship with such name does not exist");
            }

            Console.WriteLine(ship);
        }
    }
}
