namespace ClashOfKings.Models.Armies.AirForce
{
    using Attributes;

    [ArmyStructure]
    public class DragonLair : ArmyStructure
    {
        private const decimal DragonLairBuildCost = 200000;
        private const int DragonLairCapacity = 3;
        private const CityType DragonLairCityType = CityType.Capital;
        private const UnitType DragonLairUnitType = UnitType.AirForce;

        public DragonLair()
            : base(
                  DragonLairBuildCost,
                  DragonLairCapacity,
                  DragonLairCityType,
                  DragonLairUnitType)
        {
        }
    }
}
