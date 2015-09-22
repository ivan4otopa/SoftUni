using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    class SalesEmployee : RegularEmployee, ISalesEmployee
    {
        private List<Sale> sales;
        public List<Sale> Sales
        {
            get
            {
                return this.sales;
            }
            set
            {
                if (value.Count == 0)
                {
                    throw new ArgumentException("There must be at least 1 sale.");
                }
                this.sales = value;
            }
        }
        public SalesEmployee(int id, string firstName, string lastName, decimal salary, string department, List<Sale> sales)
            : base(id, firstName, lastName, salary, department)
        {
            this.Sales = sales;
        }
        public override string ToString()
        {
            return String.Format("Sales Employee: {0}; Sales:\n{1}", base.ToString(),
                string.Join("\n", this.sales.Select(s => s.ToString()).ToArray()));
        }
    }
}
