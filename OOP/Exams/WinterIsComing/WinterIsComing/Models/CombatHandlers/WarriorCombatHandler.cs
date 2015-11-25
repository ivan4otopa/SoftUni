namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    using Core.Exceptions;
    using Core;

    using Spells;

    public class WarriorCombatHandler : CombatHandler
    {
        public WarriorCombatHandler(IUnit unit)
            : base(unit)
        {
        }

        public override ISpell GenerateAttack()
        {            
            int damage = this.Unit.AttackPoints;

            if (this.Unit.HealthPoints <= 80)
            {
                damage += this.Unit.HealthPoints * 2;
            }

            var cleave = new Cleave(damage);            

            bool costsEnergy = true;

            if (this.Unit.HealthPoints < 50)
            {
                costsEnergy = false;
            }

            if (costsEnergy)
            {
                if (this.Unit.EnergyPoints < cleave.EnergyCost)
                {
                    throw new NotEnoughEnergyException(string.Format(
                        GlobalMessages.NotEnoughEnergy,
                        this.Unit.Name,
                        cleave.GetType().Name
                    ));
                }

                this.Unit.EnergyPoints -= cleave.EnergyCost;

                return new Cleave(damage);
            }
            else
            {
                return new Cleave(damage, 0);
            }
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var target = candidateTargets
                .OrderBy(ct => ct.HealthPoints)
                .ThenBy(ct => ct.Name)
                .FirstOrDefault();

            return target == null ? new List<IUnit>() : new List<IUnit>() { target };
        }
    }
}
