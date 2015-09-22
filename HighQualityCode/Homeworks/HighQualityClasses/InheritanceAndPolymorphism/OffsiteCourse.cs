using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndPolymorphism
{
    class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string name, string teacherName, IList<string> students, string town)
            : base(name, teacherName, students)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Town cannot be null or empty.");
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("OffsiteCourse ");
            result.Append(base.ToString());
            result.Append("; Town = ");
            result.Append(this.town);

            return result.ToString();
        }
    }
}
