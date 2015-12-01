namespace ClashOfKings.Engine
{
    using System.Linq;

    using Models;
    using System.Collections.Generic;
    using Contracts;

    public class ExtendedWesteros : Westeros
    {
        public override void Update()
        {
            this.UpdateHouse();

            base.Update();
        }

        public void UpdateHouse()
        {
            var housesToRemove = new List<IHouse>();
            var housesToAdd = new List<IHouse>();

            foreach (var house in this.Houses)
            {
                if (house is House && house.ControlledCities.Count() >= 10)
                {
                    var greatHouse = new GreatHouse(house.Name, house.TreasuryAmount);

                    foreach (var city in house.ControlledCities)
                    {
                        greatHouse.AddCityToHouse(city);
                    }

                    housesToRemove.Add(house);
                    housesToAdd.Add(greatHouse);
                }

                if (house is GreatHouse && house.ControlledCities.Count() < 5)
                {
                    var normalHouse = new House(house.Name, house.TreasuryAmount);

                    foreach (var city in house.ControlledCities)
                    {
                        normalHouse.AddCityToHouse(city);
                    }

                    housesToRemove.Add(house);
                    housesToAdd.Add(normalHouse);
                }
            }

            foreach (var house in housesToRemove)
            {
                this.Houses.Remove(house);
            }

            foreach (var house in housesToAdd)
            {
                this.Houses.Add(house);
            }
        }
    }
}
