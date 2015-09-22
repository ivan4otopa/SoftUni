using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.Interfaces;

namespace GameEngine.Characters
{
    class Healer : Character, IHeal
    {
        public Healer(string id, int x, int y, int healthPoints, int defencePoints, Team team, int range, int healingPoints)
            : base(id, x, y, healthPoints, defencePoints, team, range)
        {
            this.HealingPoints = healingPoints;
        }

        public int HealingPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            Character leastHealthTarget = targetsList.OrderBy(c => c.HealthPoints).First(c => c.Team == this.Team && !c.Equals(this));
            return leastHealthTarget;
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
        }
    }
}
