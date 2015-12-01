namespace ClashOfKings.Models.Armies.Cavalry
{
    using Attributes;

    [ArmyStructure]
    public class Stable : ArmyStructure
    {
        private const decimal StableBuildCost = 75000;
        private const int StableCapacity = 2500;
        private const CityType StableCityType = CityType.FortifiedCity;
        private const UnitType StableUnitType = UnitType.Cavalry;

        public Stable()
            : base(StableBuildCost, StableCapacity, StableCityType, StableUnitType)
        {
        }
    }
}
