namespace Empire.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Enum;
    using Interfaces;
    using Models;

    public class Factory : IBuildingFactory, IUnitFactory, IResourceFactory
    {
        public IBuilding CreateBuilding(string buildingType, IUnitFactory unitFactory, IResourceFactory resourceFactory)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == buildingType);

            if (type == null)
            {
                throw new ArgumentException("Unknown type");
            }

            var unit = Activator.CreateInstance(type);

            if (!(unit is IBuilding))
            {
                throw new InvalidCastException("Building factory accepts only IBuilding type");
            }

            return (IBuilding)unit;
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