namespace ClashOfKings.Models.Commands
{
    using System;
    using System.Linq;

    using Attributes;

    using Contracts;

    using Engine.Factories;

    [Command]
    public class CreateUnitCommand : Command
    {
        public CreateUnitCommand(IGameEngine engine) 
            : base(engine)
        {
        }

        public override void Execute(params string[] commandParams)
        {
            int numberOfUnits = int.Parse(commandParams[0]);

            if (numberOfUnits < 0)
            {
                throw new ArgumentOutOfRangeException("Number of units should be non-negative");
            }

            string cityName = commandParams[2];
            var city = this.Engine.Continent.GetCityByName(cityName);

            if (city == null)
            {
                throw new ArgumentNullException();
            }

            string unitType = commandParams[1];
            var factory = new UnitFactory();
            var units = factory.CreateUnits(unitType, numberOfUnits);
            
            if (city.AvailableUnitCapacity(units.First().Type) < 
                    units.Sum(u => u.HousingSpacesRequired))
            {
                throw new InvalidOperationException(string.Format(
                    "City {0} does not have enough housing spaces to accommodate {1}" +
                    " units of {2}",
                    cityName,
                    numberOfUnits,
                    unitType));
            }

            if (city.ControllingHouse.TreasuryAmount < units.Sum(u => u.TrainingCost))
            {
                throw new InvalidOperationException(string.Format(
                    "House {0} does not have enough funds to train {1} units of {2}",
                    city.ControllingHouse.Name,
                    numberOfUnits,
                    unitType));
            }

            city.AddUnits(units);
            city.ControllingHouse.TreasuryAmount -= units.Sum(u => u.TrainingCost);

            this.Engine.Render(
                "Successfully added {0} units of {1} to city {2}",
                numberOfUnits,
                unitType,
                cityName);
        }
    }
}
