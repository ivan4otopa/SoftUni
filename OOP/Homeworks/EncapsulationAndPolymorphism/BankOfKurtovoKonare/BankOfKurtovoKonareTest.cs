using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfKurtovoKonare
{
    class BankOfKurtovoKonareTest
    {
        static void Main(string[] args)
        {
            var accounts = new Account[]
            {
                new DepositAccount("Individual", 500.00m, 50.00m),
                new DepositAccount("Company", 1200.00m, 80.00m),
                new LoanAccount("Individual", 300.00m, 20.00m),
                new LoanAccount("Company", 250.00m, 10.00m),
                new MortgageAccount("Individual", 800.00m, 150.00m),
                new MortgageAccount("Company", 530.00m, 120.00m)
            };

            foreach (var account in accounts)
            {
                Console.Write("Money: ");
                decimal money = decimal.Parse(Console.ReadLine());
                Console.Write("Months: ");
                int months = int.Parse(Console.ReadLine());
                Console.WriteLine("Interest rate for " + account.Customer + " of type " + account.GetType().Name + " is: " +
                    account.CalculateInterestRate(money, months));
            }
            Console.WriteLine();
            Console.WriteLine("Before deposit: " + accounts[0].Balance);
            accounts[0].Deposit(315.00m);
            Console.WriteLine("After deposit: " + accounts[0].Balance);
            Console.WriteLine("Before withdrawal: " + accounts[1].Balance);
            accounts[1].Withdraw(200.00m);
            Console.WriteLine("After withdrawal: " + accounts[1].Balance);
            Console.WriteLine("Before deposit: " + accounts[2].Balance);
            accounts[2].Deposit(3000.00m);
            Console.WriteLine("After deposit: " + accounts[2].Balance);
            Console.WriteLine("Before deposit: " + accounts[4].Balance);
            accounts[4].Deposit(15.00m);
            Console.WriteLine("After deposit: " + accounts[4].Balance);
        }
    }
}
