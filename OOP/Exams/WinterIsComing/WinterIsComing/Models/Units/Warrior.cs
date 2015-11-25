namespace WinterIsComing.Models.Units
{
    using CombatHandlers;

    public class Warrior : Unit
    {
        private const int WarriorAttackPoints = 120;
        private const int WarriorDefensePoints = 70;
        private const int WarriorHealthPoints = 180;
        private const int WarriorEnergyPoints = 60;
        private const int WarriorRange = 1;

        public Warrior(string name, int x, int y)
            : base(
                  WarriorAttackPoints,
                  WarriorDefensePoints,
                  WarriorEnergyPoints,
                  WarriorHealthPoints,
                  name,
                  WarriorRange,
                  x,
                  y
              )
        {
            this.CombatHandler = new WarriorCombatHandler(this);
        }
    }
}
