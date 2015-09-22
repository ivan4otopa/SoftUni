using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    class Employee : Person, IEmployee
    {
        private decimal salary;
        private string department;
        public decimal Salary
        {
            get
            {
                return this.salary;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Salary must be greater than 0.");
                }
                this.salary = value;
            }
        }
        public string Department
        {
            get
            {
                return this.department;
            }
            set
            {
                if (value != "Production" && value != "Accounting" && value != "Sales" && value != "Marketing")
                {
                    throw new ArgumentException("Department must be \"Production\" or \"Accounting\" or \"Sales\" or "
                        + "\"Marketing\".");
                }
                this.department = value;
            }
        }
        public Employee(int id, string firstName, string lastName, decimal salary, string department)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
            this.Department = department;
        }
        public override string ToString()
        {
            return String.Format("Employee: {0}; Salary: {1}; Department: {2}", base.ToString(), this.salary, this.department);
        }
    }
}
