using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfKurtovoKonare
{
    class DepositAccount : Account
    {
        public DepositAccount(string customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override void Withdraw(decimal money)
        {
            this.Balance -= money;
        }

        public override decimal CalculateInterestRate(decimal money, int months)
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0;
            }
            else
            {
                decimal calcInterestRate = money * (1 + (this.InterestRate * months));
                return calcInterestRate;
            }
        }
    }
}
