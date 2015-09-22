using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    class RegularEmployee : Employee
    {
        public RegularEmployee(int id, string firstName, string lastName, decimal salary, string department)
            : base(id, firstName, lastName, salary, department)
        {
        }
        public override string ToString()
        {
            return String.Format("Regular Employee: {0}", base.ToString());
        }
    }
}
