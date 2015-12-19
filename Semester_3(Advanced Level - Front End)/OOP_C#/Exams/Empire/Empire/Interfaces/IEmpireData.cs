namespace Empire.Interfaces
{
    using System.Collections.Generic;
    using Enum;

    public interface IEmpireData
    {
        IEnumerable<IBuilding> Buildings { get; }

        void AddBuilding(IBuilding building);

        IDictionary<string, int> Units { get; }

        void AddUnit(IUnit unit);

        IDictionary<ResourceType, int> Resources { get; } 
    }
}