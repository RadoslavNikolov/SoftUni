namespace Empire.Models.Buildings
{
    using Enum;
    using Interfaces;

    public class Archery : Building
    {
        private const string UnitType = "Archer";
        private const int UnitCycleLenght = 3;

        private const ResourceType ResourceType = Enum.ResourceType.Gold;
        private new const int ResourceCycleLength = 2;
        private const int ResourceQty = 5;


        public Archery(IFactory factory) 
            : base(UnitType, UnitCycleLenght, ResourceType, ResourceCycleLength, ResourceQty, factory)
        {
        }
    }
}