namespace BeerStock
{
    using System;

    class BeerStock
    {
        static void Main()
        {
            int reservedBeers = int.Parse(Console.ReadLine());
            long totalBeers = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Exam Over")
                {
                    break;
                }
                
                string[] parts = input.Split(' ');
                long amount = long.Parse(parts[0]);
                string type = parts[1];

                if (type == "beers")
                {
                    totalBeers += amount;
                }
                else if (type == "sixpacks")
                {
                    totalBeers += 6 * amount;
                }
                else
                {
                    totalBeers += 24 * amount;
                }                
            }

            long numberOfBrokenBeers = 0;

            if (totalBeers.ToString().Length > 2)
            {
                numberOfBrokenBeers = totalBeers / 100;
            }
            totalBeers -= numberOfBrokenBeers;

            if (totalBeers >= reservedBeers)
            {
                long beersLeft = totalBeers - reservedBeers;
                long numberOfCases = beersLeft / 24;
                long notCasedBeers = beersLeft % 24;
                long numberOfSixpacks = notCasedBeers / 6;

                notCasedBeers %= 6;

                Console.WriteLine(
                    "Cheers! Beer left: {0} cases, {1} sixpacks and {2} beers.",
                    numberOfCases,
                    numberOfSixpacks,
                    notCasedBeers);
            }
            else
            {
                long beersNeeded = reservedBeers - totalBeers;
                long numberOfCases = beersNeeded / 24;
                long beersLeft = beersNeeded % 24;
                long numberOfSixpacks = beersLeft / 6;

                beersLeft %= 6;

                Console.WriteLine(
                    "Not enough beer. Beer needed: {0} cases, {1} sixpacks and {2} beers.",
                    numberOfCases,
                    numberOfSixpacks,
                    beersLeft);
            }
        }
    }
}
