namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;
    using Exceptions;
    using GameObjects.Locations;
    using MassEffect.Interfaces;

    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string shipName = commandArgs[1];
            string destinationName = commandArgs[2];

            IStarship ship = this.GameEngine.Starships.FirstOrDefault(s => s.Name == shipName);
            if (ship == null)
            {
                throw new ShipException(Messages.NoSuchShipInStarSystem);
            }
            this.ValidateAlive(ship);

            var prevousLocaton = ship.Location;
            StarSystem destination = this.GameEngine.Galaxy.GetStarSystemByName(destinationName);

            if (destination == null)
            {
                throw new ArgumentException("No such star system");
            }

            if (prevousLocaton.Name == destinationName)
            {
                throw new ShipException(string.Format(Messages.ShipAlreadyInStarSystem, destinationName));
            }

            this.GameEngine.Galaxy.TravelTo(ship, destination);
            Console.WriteLine(Messages.ShipTraveled, shipName, prevousLocaton.Name, destinationName);

        }
    }
}
