using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    interface ISalesEmployee
    {
        List<Sale> Sales
        {
            get;
            set;
        }
    }
}
