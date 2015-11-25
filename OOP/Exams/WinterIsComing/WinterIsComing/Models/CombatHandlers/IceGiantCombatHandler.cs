namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    using Core.Exceptions;
    using Core;

    using Spells;

    public class IceGiantCombatHandler : CombatHandler
    {
        private const int IceGiantAttackPointsIncreaseOnAttack = 5;

        public IceGiantCombatHandler(IUnit unit)
            : base(unit)
        {
        }

        public override ISpell GenerateAttack()
        {
            var stomp = new Stomp(this.Unit.AttackPoints);

            this.Unit.AttackPoints += IceGiantAttackPointsIncreaseOnAttack;

            if (this.Unit.EnergyPoints < stomp.EnergyCost)
            {
                throw new NotEnoughEnergyException(string.Format(
                        GlobalMessages.NotEnoughEnergy,
                        this.Unit.Name,
                        stomp.GetType().Name
                    ));
            }

            this.Unit.EnergyPoints -= stomp.EnergyCost;

            return stomp;
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            if (this.Unit.HealthPoints <= 150)
            {
                var target = candidateTargets.First();

                return new List<IUnit>() { target };
            }

            return new List<IUnit>(candidateTargets);
        }
    }
}
