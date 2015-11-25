namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;

    using Contracts;

    public abstract class CombatHandler : ICombatHandler
    {
        private IUnit unit;

        public CombatHandler(IUnit unit)
        {
            this.Unit = unit;
        }

        public IUnit Unit
        {
            get
            {
                return this.unit;
            }

            set
            {
                this.unit = value;
            }
        }

        public abstract ISpell GenerateAttack();

        public abstract IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets);
    }
}
