namespace Empire.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Enum;
    using Interfaces;
    using Models;

    public class Factory : IFactory
    {
        public IBuilding CreateBuilding(string buildingType, IFactory factory)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name.ToLowerInvariant() == buildingType);

            if (type == null)
            {
                throw new ArgumentException("Unknown type");
            }

            var building = Activator.CreateInstance(type, factory);

            if (!(building is IBuilding))
            {
                throw new InvalidCastException("Building factory accepts only IBuilding type");
            }

            return (IBuilding)building;
        }

        public IUnit CreateUnit(string unitType)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == unitType);

            if (type == null)
            {
                throw new ArgumentException("Unknown type");
            }

            var unit = Activator.CreateInstance(type);

            if (!(unit is IUnit))
            {
                throw new InvalidCastException("Unit factory accepts only IUnit type");
            }

            return (IUnit)unit;
        }

        public IResource CreateResource(ResourceType resourceType, int qty)
        {
            var resource = new Resource(resourceType, qty);

            return resource;
        }
    }
}