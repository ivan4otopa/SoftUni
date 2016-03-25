namespace SweepAndPrune
{
    class GameObject
    {
        private const int DefaultWidth = 10;
        private const int DefaultHeight = 10;

        public GameObject(string name, int x, int y)
        {
            this.Name = name;
            this.X1 = x;
            this.Y1 = y;
        }

        public string Name { get; set; }

        public int X1 { get; set; }

        public int Y1 { get; set; }

        public int X2
        {
            get
            {
                return this.X1 + DefaultWidth;
            }
        }

        public int Y2
        {
            get
            {
                return this.Y1 + DefaultHeight;
            }
        }
    }
}
