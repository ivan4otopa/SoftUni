using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    class Student : Person
    {
        private int uniqueClassNumber;
        public int UniqueClassNumber
        {
            get
            {
                return this.uniqueClassNumber;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Unique class number must be greater than 0.");
                }
                this.uniqueClassNumber = value;
            }
        }
        public Student(string name, string details, int uniqueClassNumber)
            : base(name, details)
        {
            this.UniqueClassNumber = uniqueClassNumber;
        }
        public Student(string name, int uniqueClassNumber)
            : base(name)
        {
            this.UniqueClassNumber = uniqueClassNumber;
        }
        public override string ToString()
        {
            return String.Format("Student: {0}; Unique class number: {1}", base.ToString(), this.uniqueClassNumber);
        }
    }
}
