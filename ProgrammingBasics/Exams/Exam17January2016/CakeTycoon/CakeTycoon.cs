namespace CakeTycoon
{
    using System;

    class CakeTycoon
    {
        private const decimal CakeCostIncreasePercent = 0.25M;
        static void Main()
        {
            long amountOfCakesWanted = long.Parse(Console.ReadLine());
            double kilogramsOfFlourNeeded = double.Parse(Console.ReadLine());
            uint kilogramsOfFlourAvailable = uint.Parse(Console.ReadLine());
            uint amountOfTrufflesAvailable = uint.Parse(Console.ReadLine());
            decimal priceOfOneTruffle = decimal.Parse(Console.ReadLine());

            double numberOfPossibleCakes = Math.Floor(
                kilogramsOfFlourAvailable / kilogramsOfFlourNeeded);

            if (numberOfPossibleCakes >= amountOfCakesWanted)
            {
                decimal totalTrufflesCost = amountOfTrufflesAvailable * priceOfOneTruffle;
                decimal cakePrice = 
                    totalTrufflesCost / amountOfCakesWanted + 
                    totalTrufflesCost / amountOfCakesWanted * CakeCostIncreasePercent;

                Console.WriteLine(
                    "All products available, price of a cake: {0:0.00}",
                    cakePrice);
            }
            else
            {
                double kilogramsOfFlourNeededForAllCakes = 
                    amountOfCakesWanted * kilogramsOfFlourNeeded;

                Console.WriteLine(
                    "Can make only {0} cakes, need {1:0.00} kg more flour",
                    numberOfPossibleCakes,
                    kilogramsOfFlourNeededForAllCakes - kilogramsOfFlourAvailable);
            }
        }
    }
}
