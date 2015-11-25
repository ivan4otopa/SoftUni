namespace WinterIsComing.Models.Units
{
    using CombatHandlers;

    public class IceGiant : Unit
    {
        private const int IceGiantAttackPoints = 150;
        private const int IceGiantDefensePoints = 60;
        private const int IceGiantHealthPoints = 300;
        private const int IceGiantEnergyPoints = 50;
        private const int IceGiantRange = 1;

        public IceGiant(string name, int x, int y)
            : base(
                  IceGiantAttackPoints,
                  IceGiantDefensePoints,
                  IceGiantEnergyPoints,
                  IceGiantHealthPoints,
                  name,
                  IceGiantRange,
                  x,
                  y
              )
        {
            this.CombatHandler = new IceGiantCombatHandler(this);
        }
    }
}
