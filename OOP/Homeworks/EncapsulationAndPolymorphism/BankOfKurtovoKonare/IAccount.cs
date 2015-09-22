using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfKurtovoKonare
{
    interface IAccount
    {
        string Customer
        {
            get;
            set;
        }
        decimal Balance
        {
            get;
            set;
        }
        decimal InterestRate
        {
            get;
            set;
        }

        void Withdraw(decimal money);

        decimal CalculateInterestRate(decimal money, int months);
    }
}
