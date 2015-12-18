namespace Empire.Models.Buildings
{
    using System;
    using System.Security.AccessControl;
    using EventHandlers;
    using Interfaces;

    public abstract class Building : IBuilding
    {
        public event UnitProducerEventHandler OnUnitProducer;
        public event ResourceProducerEventHandler OnResourceProducer;

        private const int ProductionDelay = 1;
        private int turnCount = 0;

        private readonly string unitType;
        private readonly ResourceType resourceType;
        private readonly int resourceCycleLength;
        private int resourceQty;
        private int unitsCycleLength;


        protected Building(string unitType, int unitsCycleLength, ResourceType resourceType, int resourceCycleLength, int resourceQuantity, int resourceCycleLength1)
        {
            this.unitType = unitType;
            this.UnitCycleLength = unitsCycleLength;
            this.resourceType = resourceType;
            this.ResourceCycleLength = resourceCycleLength;
            this.resourceType = resourceType;
            this.ResourceQuantity = resourceQuantity;
            this.resourceCycleLength = resourceCycleLength1;
        }



        private bool CanProduceResource
        {
            get
            {
                bool canProduceReasource = this.turnCount > ProductionDelay
                                           && (this.turnCount - ProductionDelay)/this.ResourceCycleLength == 0;

                return canProduceReasource;
            } 
        }

        private bool CanProduceUnit
        {
            get
            {
                bool canProduceUnit = this.turnCount > ProductionDelay
                                           && (this.turnCount - ProductionDelay) / this.UnitCycleLength == 0;

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

                this.resourceQty = value;
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
        }
    }
}