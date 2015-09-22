using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HumanStudentAndWorker
{
    class Student : Human
    {
        private string facultyNumber;
        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }
            set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Faculty Number must have between 5 and 10 digits or letters.");
                }
                this.facultyNumber = value;
            }
        }
        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }
        public override string ToString()
        {
            return String.Format("Student: {0}; Faculty Number: {1}", base.ToString(), this.facultyNumber);
        }
    }
}
