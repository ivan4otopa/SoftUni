using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    class Person
    {
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name of person cannot be null or empty.");
                }
                this.name = value;
            }
        }
        public string Details { get; set; }
        public Person(string name, string details)
        {
            this.Name = name;
            this.Details = details;
        }
        public Person(string name)
            : this(name, null)
        {
        }
        public override string ToString()
        {
            if (this.Details != null)
                return String.Format("Name: {0}; Details: {1}", this.name, this.Details);
            return String.Format("Name: {0}", this.name);
        }
    }
}
