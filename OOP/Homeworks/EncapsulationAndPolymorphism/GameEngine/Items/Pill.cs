using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Items
{
    class Pill : Bonus
    {
        public Pill(string id)
            : base(id, 0, 0, 100)
        {
        }
    }
}
