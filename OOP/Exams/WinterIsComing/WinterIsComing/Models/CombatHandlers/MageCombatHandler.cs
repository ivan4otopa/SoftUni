namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    using Core;
    using Core.Exceptions;

    using Spells;

    public class MageCombatHandler : CombatHandler
    {
        private bool fireBreathCasted = false;

        public MageCombatHandler(IUnit unit)
            : base(unit)
        {
        }

        public override ISpell GenerateAttack()
        {
            if (!fireBreathCasted)
            {
                var fireBreath = new FireBreath(this.Unit.AttackPoints);

                if (this.Unit.EnergyPoints >= fireBreath.EnergyCost)
                {
                    this.fireBreathCasted = true;

                    this.Unit.EnergyPoints -= fireBreath.EnergyCost;

                    return fireBreath;
                }
                else
                {
                    throw new NotEnoughEnergyException(string.Format(
                        GlobalMessages.NotEnoughEnergy,
                        this.Unit.Name,
                        fireBreath.GetType().Name
                    ));
                }
            }
            else
            {
                var blizzard = new Blizzard(this.Unit.AttackPoints * 2);

                if (this.Unit.EnergyPoints >= blizzard.EnergyCost)
                {
                    fireBreathCasted = false;

                    this.Unit.EnergyPoints -= blizzard.EnergyCost;

                    return blizzard;
                }
                else
                {
                    throw new NotEnoughEnergyException(string.Format(
                        GlobalMessages.NotEnoughEnergy,
                        this.Unit.Name,
                        blizzard.GetType().Name
                    ));
                }
            }
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var targets = candidateTargets
                .OrderByDescending(ct => ct.HealthPoints)
                .ThenBy(ct => ct.Name)
                .Take(3);

            return targets.ToList();
        }
    }
}
