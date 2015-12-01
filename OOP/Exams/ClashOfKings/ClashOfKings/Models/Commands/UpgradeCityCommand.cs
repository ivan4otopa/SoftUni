namespace ClashOfKings.Models.Commands
{
    using System;
    using Attributes;
    using Contracts;

    [Command]
    public class UpgradeCityCommand : Command
    {
        public UpgradeCityCommand(IGameEngine engine) 
            : base(engine)
        {
        }

        public override void Execute(params string[] commandParams)
        {
            string cityName = commandParams[0];
            var city = this.Engine.Continent.GetCityByName(cityName);

            if (city == null)
            {
                throw new ArgumentNullException();
            }

            if (city.ControllingHouse.TreasuryAmount < city.UpgradeCost &&
                !(city.ControllingHouse is GreatHouse))
            {
                throw new InvalidOperationException(string.Format(
                    "House {0} has insufficient funds to upgrade {1}",
                    city.ControllingHouse.Name,
                    cityName));
            }

            city.ControllingHouse.TreasuryAmount -= city.UpgradeCost;
            city.Upgrade();

            this.Engine.Render(
                "City {0} successfully upgraded to {1}",
                cityName,
                city.CityType);
        }
    }
}
