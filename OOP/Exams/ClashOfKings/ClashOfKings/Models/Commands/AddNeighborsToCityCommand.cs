namespace ClashOfKings.Models.Commands
{
    using System;

    using Attributes;

    using Contracts;

    [Command]
    class AddNeighborsToCityCommand : Command
    {
        public AddNeighborsToCityCommand(IGameEngine engine) 
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

            ICity neighbor = null;
            int distance = 0;

            for (int i = 1; i < commandParams.Length; i += 2)
            {
                neighbor = this.Engine.Continent.GetCityByName(commandParams[i]);

                if (neighbor == null)
                {
                    throw new ArgumentNullException("Specified neighbor does not exist");
                }

                distance = int.Parse(commandParams[i + 1]);

                if (distance < 0)
                {
                    throw new ArgumentOutOfRangeException("The distance between the cities cannot be negative");
                }

                this.Engine.Continent.CityNeighborsAndDistances[city].Add(neighbor, distance);
                this.Engine.Continent.CityNeighborsAndDistances[neighbor].Add(city, distance);
            }

            this.Engine.Render("All valid neighbor records added for city {0}", cityName);
        }
    }
}
