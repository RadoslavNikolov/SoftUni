namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;
    using System.Runtime.ExceptionServices;
    using System.Threading;
    using Exceptions;
    using GameObjects.Enhancements;
    using GameObjects.Ships;
    using MassEffect.Interfaces;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string type = commandArgs[1];
            string shipName = commandArgs[2];
            string locationName = commandArgs[3];

            bool shipAlreadyExists = this.GameEngine.Starships.Any(sh => sh.Name == shipName);

            if (shipAlreadyExists)
            {
                throw new ArgumentException(string.Format(Messages.DuplicateShipName));
            }

            var location = this.GameEngine.Galaxy.GetStarSystemByName(locationName);
            StarshipType starshipType = (StarshipType) Enum.Parse(typeof (StarshipType), type);
            var ship = this.GameEngine.ShipFactory.CreateShip(starshipType, shipName, location);

            for (int i = 4; i < commandArgs.Length; i++)
            {
                EnhancementType enchaType = (EnhancementType) Enum.Parse(typeof (EnhancementType), commandArgs[i]);
                var enchancement = this.GameEngine.EnhancementFactory.Create(enchaType);
                ship.AddEnhancement(enchancement);
            }

            this.GameEngine.Starships.Add(ship);

            Console.WriteLine(Messages.CreatedShip, starshipType, shipName);
        }
    }
}
