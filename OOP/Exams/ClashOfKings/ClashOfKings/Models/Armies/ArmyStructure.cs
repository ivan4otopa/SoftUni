namespace ClashOfKings.Models.Armies
{
    using System;
    using Attributes;
    using Contracts;

    [ArmyStructure]
    public class ArmyStructure : IArmyStructure
    {
        private decimal buildCost;
        private int capacity;

        protected ArmyStructure(
            decimal buildCost,
            int capacity,
            CityType cityType,
            UnitType unitType)
        {
            this.BuildCost = buildCost;
            this.Capacity = capacity;
            this.RequiredCityType = cityType;
            this.UnitType = unitType;
        }

        public decimal BuildCost
        {
            get
            {
                return this.buildCost;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "buildCost",
                        "A structure's build cost cannot be negative");
                }

                this.buildCost = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "capacity",
                        "A structure's capacity cannot be negative");
                }

                this.capacity = value;
            }
        }

        public CityType RequiredCityType { get; private set; }

        public UnitType UnitType { get; private set; }
    }
}
