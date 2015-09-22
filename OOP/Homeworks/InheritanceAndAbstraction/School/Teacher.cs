using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    class Teacher : Person
    {
        private IList<Discipline> disciplines = new List<Discipline>();
        public Teacher(string name, IList<Discipline> disciplines, string details)
            : base(name, details)
        {
            this.disciplines = disciplines;
        }
        public Teacher(string name, IList<Discipline> disciplines)
            : base(name)
        {
            this.disciplines = disciplines;
        }
        public override string ToString()
        {
            if (this.Details != null)
            {
                return String.Format("Teacher: {0}; Disciplines:\n{1}", base.ToString(),
                    string.Join("\n", this.disciplines.Select(d => d.ToString()).ToArray()));
            }
            return String.Format("Teacher: {0}; Disciplines:\n{1}", base.ToString(),
                string.Join("\n", this.disciplines.Select(d => d.ToString()).ToArray()));
        }
    }
}