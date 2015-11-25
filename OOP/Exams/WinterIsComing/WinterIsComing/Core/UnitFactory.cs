namespace WinterIsComing.Core
{
    using System;
    using Contracts;
    using Models;
    using Models.Units;

    public static class UnitFactory
    {
        public static IUnit Create(UnitType type, string name, int x, int y)
        {
            switch (type)
            {
                case UnitType.Warrior:
                    var warrior = new Warrior(name, x, y);

                    return warrior;
                case UnitType.Mage:
                    var mage = new Mage(name, x, y);

                    return mage;
                case UnitType.IceGiant:
                    var iceGiant = new IceGiant(name, x, y);

                    return iceGiant;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
