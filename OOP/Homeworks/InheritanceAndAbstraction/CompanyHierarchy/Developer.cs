using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    class Developer : RegularEmployee, IDeveloper
    {
        private List<Project> projects;
        public List<Project> Projects
        {
            get
            {
                return this.projects;
            }
            set
            {
                if (value.Count == 0)
                {
                    throw new ArgumentException("There must be at least 1 project.");
                }
                this.projects = value;
            }
        }
        public Developer(int id, string firstName, string lastName, decimal salary, string department, List<Project> projects)
            : base(id, firstName, lastName, salary, department)
        {
            this.Projects = projects;
        }
        public override string ToString()
        {
            return String.Format("Developer: {0}; Projects:\n{1}", base.ToString(),
                string.Join("\n", this.projects.Select(p => p.ToString()).ToArray()));
        }
    }
}
