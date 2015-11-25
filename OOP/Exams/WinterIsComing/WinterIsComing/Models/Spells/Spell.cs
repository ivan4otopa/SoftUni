namespace WinterIsComing.Models.Spells
{
    using Contracts;

    abstract class Spell : ISpell
    {
        private int damage;
        private int energyCost;

        public Spell(int damage, int energyCost)
        {
            this.Damage = damage;
            this.EnergyCost = energyCost;
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }

            private set
            {
                this.damage = value;
            }
        }

        public int EnergyCost
        {
            get
            {
                return this.energyCost;
            }

            private set
            {
                this.energyCost = value;
            }
        }
    }
}
