using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    interface ISale
    {
        string ProductName
        {
            get;
            set;
        }
        DateTime Date
        {
            get;
            set;
        }
        decimal Price
        {
            get;
            set;
        }
    }
}
