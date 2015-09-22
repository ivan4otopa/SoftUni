using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfKurtovoKonare
{
    class MortgageAccount : Account
    {
        public MortgageAccount(string customer, decimal balance, decimal interestRate)
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
                if (months <= 6)
                {
                    return 0;
                }
                else
                {
                    calcInterestRate = money * (1 + (this.InterestRate * (months - 6)));
                    return calcInterestRate;
                }
            }
            else if (this.Customer == "Company")
            {
                if (months <= 12)
                {
                    calcInterestRate = (money * (1 + (this.InterestRate * months))) / 2;
                    return calcInterestRate;
                }
                else
                {
                    calcInterestRate = money * (1 + (this.InterestRate * (months - 12)));
                    return calcInterestRate;
                }
            }
            return calcInterestRate;
        }
    }
}
