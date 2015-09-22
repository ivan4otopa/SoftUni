using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    class Kitten : Cat
    {
        public Kitten(string name, int age)
            : base(name, age, "female")
        {
        }
        public override string ToString()
        {
            return String.Format("Kitten: {0}", base.ToString());
        }
    }
}
