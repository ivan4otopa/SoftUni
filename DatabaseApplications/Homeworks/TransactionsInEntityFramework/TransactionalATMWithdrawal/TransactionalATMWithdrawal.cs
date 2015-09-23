namespace TransactionalATMWithdrawal
{
    using System;
    using System.Text.RegularExpressions;

    class TransactionalATMWithdrawal
    {
        static void Main(string[] args)
        {
            //Throws exception
            //WithdrawMoney(200, 1);

            //Succeeds
            //WithdrawMoney(200, 5);
        }

        static void WithdrawMoney(decimal money, int accountId)
        {
            using (var context = new ATMEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    var account = context.CardAccounts.Find(accountId);

                    try
                    {
                        Regex regex = new Regex(@"\d+");
                        Match cardNumberMatch = regex.Match(account.CardNumber);

                        if (!cardNumberMatch.Success)
                        {
                            throw new InvalidOperationException("The card number is invalid.");
                        }

                        Match cardPinMatch = regex.Match(account.CardPIN);

                        if (!cardPinMatch.Success)
                        {
                            throw new InvalidOperationException("The card pin is invalid.");
                        }

                        if (account.CardCash < money)
                        {
                            throw new InvalidOperationException("Not enough money to withdraw.");
                        }

                        context.TransactionHistories.Add(new TransactionHistory()
                        {
                            CardNumber = account.CardNumber,
                            TransactionDate = DateTime.Now,
                            Amount = money
                        });

                        account.CardCash -= money;
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (InvalidOperationException)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }
    }
}
