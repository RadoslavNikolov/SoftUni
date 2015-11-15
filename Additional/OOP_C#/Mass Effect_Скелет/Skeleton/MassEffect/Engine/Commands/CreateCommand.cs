namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;
    using GameObjects.Enhancements;
    using GameObjects.Locations;
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
            bool shipAlreadyExists = this.GameEngine.Starships.Any(s => s.Name == shipName);

            if (shipAlreadyExists)
            {
                throw new ArgumentException(string.Format(Messages.DuplicateShipName));
            }

            var location = this.GameEngine.Galaxy.GetStarSystemByName(locationName);
            StarshipType shipType = (StarshipType) Enum.Parse(typeof (StarshipType), type);

            IStarship newShip = this.GameEngine.ShipFactory.CreateShip(shipType, shipName, location);
            this.GameEngine.Starships.Add(newShip);


            for (int i = 4; i < commandArgs.Length; i++)
            {
                var enhancementType = (EnhancementType)
                    Enum.Parse(typeof (EnhancementType), commandArgs[i]);

                Enhancement enhancement = null;
                enhancement = this.GameEngine.EnhancementFactory.Create(enhancementType);
                newShip.AddEnhancement(enhancement);
            }

            Console.WriteLine(Messages.CreatedShip, shipType, shipName);       
        }
    }
}
