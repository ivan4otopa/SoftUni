namespace WinterIsComing.Models.Spells
{
    class Blizzard : Spell
    {
        private const int BlizzardEnergyCost = 40;

        public Blizzard(int damage)
            : base(damage, BlizzardEnergyCost)
        {
        }
    }
}
