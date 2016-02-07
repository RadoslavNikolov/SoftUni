namespace Empire.Models.Buildings
{
    using System;
    using System.Security.AccessControl;
    using EventHandlers;
    using EventsArgs;
    using Interfaces;
    using ResourceType = Enum.ResourceType;

    public abstract class Building : IBuilding
    {
        public event UnitProducerEventHandler OnUnitProducer;
        public event ResourceProducerEventHandler OnResourceProducer;

        private const int ProductionDelay = 1;
        private int turnCount = 0;

        private readonly string unitType;
        private readonly ResourceType resourceType;
        private int resourceCycleLength;
        private int resourceQty;
        private int unitsCycleLength;
        private readonly IFactory facotry;


        protected Building(string unitType, int unitsCycleLength, ResourceType resourceType, int resourceCycleLength, int resourceQuantity, IFactory factory)
        {
            this.unitType = unitType;
            this.UnitCycleLength = unitsCycleLength;
            this.resourceType = resourceType;
            this.ResourceCycleLength = resourceCycleLength;
            this.ResourceQuantity = resourceQuantity;
            this.facotry = factory;
        }



        private bool CanProduceResource
        {
            get
            {
                bool canProduceReasource = this.turnCount > ProductionDelay
                                           && (this.turnCount - ProductionDelay)%this.ResourceCycleLength == 0;

                return canProduceReasource;
            } 
        }

        private bool CanProduceUnit
        {
            get
            {
                bool canProduceUnit = this.turnCount > ProductionDelay
                                           && (this.turnCount - ProductionDelay) % this.UnitCycleLength == 0;

                return canProduceUnit;
            }
        }

        public int UnitCycleLength
        {
            get { return this.unitsCycleLength; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                         "value",
                         "The length of the production cycle for units should be positive.");
                }

                this.unitsCycleLength = value;
            }
        }

        public int ResourceCycleLength
        {
            get { return this.resourceCycleLength; }
            set
            {
                if (value <= 0)
                {
                   throw new ArgumentOutOfRangeException(
                        "value", 
                        "The length of the production cycle for units should be positive.");
                }

                this.resourceCycleLength = value;
            }
        }

        private int ResourceQuantity
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "value",
                        "The resource quantity produced by the building cannot be negative.");
                }

                this.resourceQty = value;
            }
        }

        public void Update()
        {
            this.turnCount++;

            if (this.CanProduceUnit  && this.OnUnitProducer != null)
            {
                var unit = this.facotry.CreateUnit(this.unitType);

                this.OnUnitProducer(this, new UnitProducerEventArgs(unit));
            }

            if (this.CanProduceResource && this.OnResourceProducer != null)
            {
                var resource = this.facotry.CreateResource(this.resourceType, this.resourceQty);

                this.OnResourceProducer(this, new ResourceProducerEventArgs(resource));

            }
        }


        public override string ToString()
        {
            int turnsUntilUnit = this.UnitCycleLength - (this.turnCount - ProductionDelay) % this.UnitCycleLength;
            int turnsUntilResource = this.resourceCycleLength - (this.turnCount - ProductionDelay) % this.resourceCycleLength;

            var result = string.Format(
                "--{0}: {1} turns ({2} turns until {3}, {4} turns until {5})",
                this.GetType().Name,
                this.turnCount - ProductionDelay,
                turnsUntilUnit,
                this.unitType,
                turnsUntilResource,
                this.resourceType);

            return result;
        }

    }
}