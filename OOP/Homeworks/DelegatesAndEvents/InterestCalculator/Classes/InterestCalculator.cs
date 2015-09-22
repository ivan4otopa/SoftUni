using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterestCalculator.Delegates;

namespace InterestCalculator.Classes
{
    class InterestCalculator
    {
        public InterestCalculator(decimal money, decimal interest, int years, CalcuateInterest CalculateIncome)
        {
            this.Money = money;
            this.Interest = interest;
            this.Years = years;
            this.CalculatedInterest = CalculateIncome(this.Money, this.Interest, this.Years);
        }

        public decimal Money { get; set; }
        public decimal Interest { get; set; }
        public int Years { get; set; }
        public string CalculatedInterest { get; set; }
    }
}
