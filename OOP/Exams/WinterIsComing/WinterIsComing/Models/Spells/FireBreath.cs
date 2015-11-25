namespace WinterIsComing.Models.Spells
{
    class FireBreath : Spell
    {
        private const int FireBreathEnergyCost = 30;

        public FireBreath(int damage)
            : base(damage, FireBreathEnergyCost)
        {
        }
    }
}
