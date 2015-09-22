using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    interface IManager
    {
        List<Employee> Employees
        {
            get;
            set;
        }
    }
}
