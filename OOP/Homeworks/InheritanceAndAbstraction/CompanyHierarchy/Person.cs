using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    class Person : IPerson
    {
        private int id;
        private string firstName;
        private string lastName;
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Id must be greater than zero.");
                }
                this.id = value;
            }
        }
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First Name cannot be emptyd.");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last Name cannot be emptyd.");
                }
                this.lastName = value;
            }
        }
        public Person(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public override string ToString()
        {
            return String.Format("Id: {0}; First Name: {1}; Last Name: {2}", this.id, this.firstName, this.lastName);
        }
    }
}
