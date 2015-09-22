using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfKurtovoKonare
{
    class LoanAccount : Account
    {
        public LoanAccount(string customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override void Withdraw(decimal money)
        {
            this.Balance -= money;
        }

        public override decimal CalculateInterestRate(decimal money, int months)
        {
            decimal calcInterestRate = money * (1 + (this.InterestRate * months));
            if (this.Customer == "Individual")
            {
                if(months <= 3)
                {
                    return 0;
                }
                else
                {
                    return calcInterestRate;
                }
            }
            else if (this.Customer == "Company")
            {
                if (months <= 2)
                {
                    return 0;
                }
                else
                {
                    return calcInterestRate;
                }
            }
            return calcInterestRate;
        }
    }
}
