using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentClass.Classes
{
    public class PropertyChangedEventArgs : EventArgs
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string PreviousName { get; set; }
        public int PreviousAge { get; set; }
        public string ChangedProperty { get; set; }
    }
}
