namespace Empire.Models.Buildings
{
    using Enum;
    using Interfaces;

    public class Barracks : Building
    {
        private const string UnitType = "Swordsman";
        private const int UnitCycleLenght = 4;

        private const ResourceType ResourceType = Enum.ResourceType.Steel;
        private new const int ResourceCycleLength = 3;
        private const int ResourceQty = 10;
         
        public Barracks(IFactory factory) 
            : base(UnitType, UnitCycleLenght, ResourceType, ResourceCycleLength, ResourceQty, factory)
        {
        }
    }
}