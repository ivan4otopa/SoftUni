using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HumanStudentAndWorker
{
    abstract class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public override string ToString()
        {
            return String.Format("First Name: {0}; Last Name: {1}", this.FirstName, this.LastName);
        }
    }
}
