using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericListVersion.Attributes
{

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Enum |
        AttributeTargets.Method)]

    class VersionAttribute : System.Attribute
    {
        public string version;
        public int Major { get; set; }
        public int Minor { get; set; }

        public VersionAttribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
            this.version = this.Major + "." + this.Minor;
        }
    }
}
