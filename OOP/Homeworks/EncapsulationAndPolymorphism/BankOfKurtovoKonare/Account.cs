using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfKurtovoKonare
{
    abstract class Account : IAccount
    {
        private string customer;

        public Account(string customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public string Customer
        {
            get
            {
                return this.customer;
            }
            set
            {
                if (value != "Individual" && value != "Company")
                {
                    throw new ArgumentException("Customer must either be \"Individual\" or \"Company\"");
                }
                this.customer = value;
            }
        }
        public decimal Balance { get; set; }
        public decimal InterestRate { get; set; }

        public void Deposit(decimal money)
        {
            this.Balance += money;
        }

        public abstract void Withdraw(decimal money);

        public abstract decimal CalculateInterestRate(decimal money, int months);
    }
}
