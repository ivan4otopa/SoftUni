namespace ClashOfKings.Models
{
    using System;

    using Contracts;

    public class GreatHouse : House
    {
        public GreatHouse(string name, decimal initialTreasuryAmount) 
            : base(name, initialTreasuryAmount)
        {
        }

        public override decimal TreasuryAmount { get; set; }

        public override void UpgradeCity(ICity city)
        {
            if (city == null)
            {
                throw new ArgumentNullException();
            }

            this.TreasuryAmount -= city.UpgradeCost;

            city.Upgrade();
        }

        public override string Print()
        {
            return string.Format("Great {0}", base.Print());
        }
    }
}
