using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    class Manager : Employee, IManager
    {
        private List<Employee> employees;
        public List<Employee> Employees
        {
            get
            {
                return this.employees;
            }
            set
            {
                if (value.Count == 0)
                {
                    throw new ArgumentException("There must be at least 1 employee.");
                }
                this.employees = value;
            }
        }
        public Manager(int id, string firstName, string lastName, decimal salary, string department, List<Employee> employees)
            : base(id, firstName, lastName, salary, department)
        {
            this.Employees = employees;
        }
        public override string ToString()
        {
            return String.Format("Manager: {0}; Employees:\n{1}", base.ToString(), 
                string.Join("\n", this.employees.Select(e => e.ToString()).ToArray()));
        }
    }
}
