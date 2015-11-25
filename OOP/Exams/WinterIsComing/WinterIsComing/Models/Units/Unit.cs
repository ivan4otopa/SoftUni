namespace WinterIsComing.Models.Units
{
    using System.Text;

    using Contracts;

    public abstract class Unit : IUnit
    {
        private int attackPoints;
        private int defensePoints;
        private int energyPoints;
        private int healthPoints;
        private string name;
        private int range;
        private int x;
        private int y;
        private ICombatHandler combatHandler;

        public Unit(
            int attackPoints,
            int defensePoints,
            int energyPoints,
            int healthPoints,
            string name,
            int range,
            int x,
            int y
        )
        {
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.EnergyPoints = energyPoints;
            this.HealthPoints = healthPoints;
            this.Name = name;
            this.Range = range;
            this.X = x;
            this.Y = y;
        }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }

            set
            {
                this.attackPoints = value;
            }
        }        

        public int DefensePoints
        {
            get
            {
                return this.defensePoints;
            }

            set
            {
                this.defensePoints = value;
            }
        }

        public int EnergyPoints
        {
            get
            {
                return this.energyPoints;
            }

            set
            {
                this.energyPoints = value;
            }
        }

        public int HealthPoints
        {
            get
            {
                return this.healthPoints;
            }

            set
            {
                this.healthPoints = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.name = value;
            }
        }

        public int Range
        {
            get
            {
                return this.range;
            }

            private set
            {
                this.range = value;
            }
        }

        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
            }
        }

        public ICombatHandler CombatHandler
        {
            get
            {
                return this.combatHandler;
            }

            internal set
            {
                this.combatHandler = value;
            }
        }

        public override string ToString()
        {
            if (this.healthPoints > 0)
            {
                return string.Format(
                    ">{0} - {1} at ({2},{3})\n-Health points = {4}\n-Attack points = " +
                    "{5}\n-Defense points = {6}\n-Energy points = {7}\n-Range = {8}",
                    this.name,
                    this.GetType().Name,
                    this.x,
                    this.y,
                    this.healthPoints,
                    this.attackPoints,
                    this.defensePoints,
                    this.energyPoints,
                    this.range
                );
            }
            else
            {
                return string.Format(
                    ">{0} - {1} at ({2},{3})\n(Dead)",
                    this.name,
                    this.GetType().Name,
                    this.x,
                    this.y
                );
            }
        }
    }
}
