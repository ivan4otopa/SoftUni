namespace GrandTheftExamo
{
    using System;
    using System.Numerics;

    class GrandTheftExamo
    {
        static void Main()
        {
            int escapeAttempts = int.Parse(Console.ReadLine());
            int thieves = 0;
            int beers = 0;
            int thievesSlapped = 0;
            BigInteger thievesEscaped = 0;
            int attemptThievesEscaped = 0;
            BigInteger totalBeers = 0;
            BigInteger beerPackSpace = 6;

            for (int i = 0; i < escapeAttempts; i++)
            {
                thieves = int.Parse(Console.ReadLine());
                beers = int.Parse(Console.ReadLine());

                if (thieves <= 5)
                {
                    thievesSlapped += thieves;
                }
                else
                {
                    attemptThievesEscaped = thieves - 5;
                    thievesEscaped += attemptThievesEscaped;
                    thievesSlapped += thieves - attemptThievesEscaped;
                }

                totalBeers += beers;
            }

            BigInteger beerPacks = totalBeers / beerPackSpace;
            BigInteger beerBottles = totalBeers % beerPackSpace;

            Console.WriteLine("{0} thieves slapped.\n{1} thieves escaped.\n{2} packs, {3} bottles.", thievesSlapped, thievesEscaped, beerPacks, beerBottles);
        }
    }
}
