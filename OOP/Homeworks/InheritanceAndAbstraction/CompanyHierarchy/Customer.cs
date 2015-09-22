using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    class Customer : Person, ICustomer
    {
        private decimal netPurchaseAmount;
        public decimal NetPurchaseAmount
        {
            get
            {
                return this.netPurchaseAmount;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Net Purchase Amount must be greater than 0.");
                }
                this.netPurchaseAmount = value;
            }
        }
        public Customer(int id, string firstName, string lastName, decimal netPurchaseAmount)
            : base(id, firstName, lastName)
        {
            this.NetPurchaseAmount = netPurchaseAmount;
        }
        public override string ToString()
        {
            return String.Format("Customer: {0}; Net Purchase Amount: {1}", base.ToString(), this.netPurchaseAmount);
        }
    }
}
