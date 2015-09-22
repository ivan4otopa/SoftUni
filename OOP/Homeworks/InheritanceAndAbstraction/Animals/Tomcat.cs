using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    class Tomcat : Cat
    {
        public Tomcat(string name, int age)
            : base(name, age, "male")
        {
        }
        public override string ToString()
        {
            return String.Format("Tomcat: {0}", base.ToString());
        }
    }
}
