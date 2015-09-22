using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterestCalculator.Classes;

namespace InterestCalculator
{
    class InterestCalculatorTest
    {
        static void Main(string[] args)
        {
            InterestCalculator.Classes.InterestCalculator interestCalcultorOne = new InterestCalculator.Classes.InterestCalculator(
                500m, 5.6m, 10, GetCompoundInterest);
            InterestCalculator.Classes.InterestCalculator interestCalcultorTwo = new InterestCalculator.Classes.InterestCalculator(
                2500m, 7.2m, 15, GetSimpleInterest);

            Console.WriteLine(interestCalcultorOne.CalculatedInterest);
            Console.WriteLine(interestCalcultorTwo.CalculatedInterest);
        }

        public static string GetSimpleInterest(decimal sum, decimal interest, int years)
        {
            decimal simpleInterest = sum * (1 + ((interest / 100) * years));
            return simpleInterest.ToString("F4");
        }

        public static string GetCompoundInterest(decimal sum, decimal interest, int years)
        {
            int n = 12;
            decimal compoundInterest = (decimal)((double)sum * (Math.Pow((double)(1 + ((interest / 100) / n)), years * n)));
            return compoundInterest.ToString("F4");
        }
    }
}
