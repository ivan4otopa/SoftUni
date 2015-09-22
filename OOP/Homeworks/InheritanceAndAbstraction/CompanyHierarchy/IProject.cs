using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    interface IProject
    {
        string ProjectName
        {
            get;
            set;
        }
        DateTime ProjectStartDate
        {
            get;
            set;
        }
        string Details
        {
            get;
            set;
        }
        State State
        {
            get;
            set;
        }
        void CloseProject();
    }
}
