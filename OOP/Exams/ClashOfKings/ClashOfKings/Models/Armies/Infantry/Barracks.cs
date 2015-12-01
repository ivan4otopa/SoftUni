namespace ClashOfKings.Models.Armies.Infantry
{
    using Attributes;

    [ArmyStructure]
    public class Barracks : ArmyStructure
    {
        private const decimal BarracksBuildCost = 15000;
        private const int BarracksCapacity = 5000;
        private const CityType BarracksCityType = CityType.Keep;
        private const UnitType BarracksUnitType = UnitType.Infantry;

        public Barracks()
            : base(BarracksBuildCost, BarracksCapacity, BarracksCityType, BarracksUnitType)
        {
        }
    }
}
