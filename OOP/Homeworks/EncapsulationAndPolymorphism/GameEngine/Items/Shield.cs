using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Items
{
    class Shield : Item
    {
        public Shield(string id)
            : base(id, 0, 50, 0)
        {
        }
    }
}
