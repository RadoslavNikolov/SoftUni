namespace Empire.Core
{
    using System;
    using System.Collections.Generic;
    using Enum;
    using Interfaces;

    public class EmpireData : IEmpireData
    {
        private readonly ICollection<IBuilding> buildings = new List<IBuilding>();

        public EmpireData()
        {
            this.Units = new Dictionary<string, int>();
            this.Resources = new Dictionary<ResourceType, int>();
            this.InitResources();
        }

        public IEnumerable<IBuilding> Buildings
        {
            get { return this.buildings; }
        }

        public IDictionary<ResourceType, int> Resources { get; }

        public IDictionary<string, int> Units { get; }

        public void AddBuilding(IBuilding building)
        {
            if (building == null)
            {
                throw new ArgumentNullException("building");
            }

            this.buildings.Add(building);
        }

        public void AddUnit(IUnit unit)
        {
            if (unit ==  null)
            {
                throw new ArgumentNullException("unit");
            }

            var unitType = unit.GetType().Name;

            if (!this.Units.ContainsKey(unitType))
            {
                this.Units.Add(unitType,0);
            }

            this.Units[unitType]++;
        }

        

        private void InitResources()
        {
            var resourceTypes = Enum.GetValues(typeof (ResourceType));

            foreach (ResourceType resourceType in resourceTypes)
            {
                this.Resources.Add(resourceType, 0);
            }
        }
    }
}