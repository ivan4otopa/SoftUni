namespace WinterIsComing.Models.Spells
{
    class Cleave : Spell
    {
        private const int CleaveEnergyCost = 15;

        public Cleave(int damage, int energyCost = CleaveEnergyCost)
            : base(damage, energyCost)
        {
        }
    }
}
