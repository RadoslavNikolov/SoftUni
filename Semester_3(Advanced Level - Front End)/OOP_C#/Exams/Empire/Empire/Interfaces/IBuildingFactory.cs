namespace Empire.Interfaces
{
    public interface IBuildingFactory
    {
        IBuilding CreateBuilding(string buildingType, IFactory factory);
    }
}