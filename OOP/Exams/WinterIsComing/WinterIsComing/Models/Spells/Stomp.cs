namespace WinterIsComing.Models.Spells
{
    class Stomp : Spell
    {
        private const int StompEnergyCost = 10;

        public Stomp(int damage)
            : base(damage, StompEnergyCost)
        {
        }
    }
}
