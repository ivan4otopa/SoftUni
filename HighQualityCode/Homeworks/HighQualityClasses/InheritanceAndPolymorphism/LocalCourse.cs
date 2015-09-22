using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndPolymorphism
{
    class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string name, string teacherName, IList<string> students, string lab)
            : base(name, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Lab cannot be null or empty.");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse ");
            result.Append(base.ToString());
            result.Append("; Lab = ");
            result.Append(this.lab);

            return result.ToString();
        }
    }
}
