namespace ClashOfKings.Models.Commands
{
    using System;

    using Attributes;

    using Contracts;

    using Engine.Factories;

    [Command]
    public class BuildStructureCommand : Command
    {
        public BuildStructureCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute(params string[] commandParams)
        {
            string cityName = commandParams[1];
            var city = this.Engine.Continent.GetCityByName(cityName);

            if (city == null)
            {
                throw new ArgumentNullException();
            }

            string structureName = commandParams[0];
            var factory = new ArmyStructureFactory();
            IArmyStructure armyStructure = factory.CreateStructure(structureName);

            if (city.CityType < armyStructure.RequiredCityType)
            {
                throw new InvalidOperationException("Structure requires a more advanced city");
            }

            if (armyStructure.BuildCost > city.ControllingHouse.TreasuryAmount)
            {
                throw new InvalidOperationException(string.Format(
                    "House {0} doesn't have sufficient funds to build {1}",
                    city.ControllingHouse.Name,
                    structureName));
            }

            city.ControllingHouse.TreasuryAmount -= armyStructure.BuildCost;
            city.AddArmyStructure(armyStructure);

            this.Engine.Render("Successfully built {0} in {1}", structureName, cityName);
        }
    }
}
