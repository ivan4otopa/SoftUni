using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngine.Interfaces;

namespace GameEngine.Characters
{
    class Mage : Character, IAttack
    {
        public Mage(string id, int x, int y, int healthPoints, int defencePoints, Team team, int range, int attackPoints)
            : base(id, x, y, healthPoints, defencePoints, team, range)
        {
            this.AttackPoints = attackPoints;
        }

        public int AttackPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            Character farthestTarget = targetsList.Last(c => c.IsAlive && this.Team != c.Team);
            return farthestTarget;
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
