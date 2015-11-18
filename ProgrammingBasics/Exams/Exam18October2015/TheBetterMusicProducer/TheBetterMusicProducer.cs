namespace TheBetterMusicProducer
{
    using System;
    using System.Globalization;

    class TheBetterMusicProducer
    {
        private const decimal CurrencyConvertionEuro = 1.94M;
        private const decimal CurrencyConvertionDollars = 1.72M;
        private const decimal CurrencyConvertionPesos = 332.74M;
        private const decimal ThirtyFivePercent = 35M / 100M;
        private const decimal TwentyPercent = 20M / 100M;
        private const decimal FifteenPercent = 15M / 100M;

        static void Main()
        {
            int numberOfAlbumsSoldInEurope = int.Parse(Console.ReadLine());
            decimal albumPriceInEuro = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            int numberOfAlbumsSoldInNorthAmerica = int.Parse(Console.ReadLine());
            decimal albumPriceInDollars = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            int numberOfAlbumsSoldInSouthAmerica = int.Parse(Console.ReadLine());
            decimal albumPriceInPesos = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            int numberOfConcertsDuringTour = int.Parse(Console.ReadLine());
            decimal concertProfitInEuro = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            decimal totalEuropeAlbumPriceInLeva = numberOfAlbumsSoldInEurope * albumPriceInEuro * CurrencyConvertionEuro;
            decimal totalNorthAmericaAlbumPriceInLeva = numberOfAlbumsSoldInNorthAmerica * albumPriceInDollars * CurrencyConvertionDollars;
            decimal totalSouthAmericaAlbumPriceInLeva = numberOfAlbumsSoldInSouthAmerica * albumPriceInPesos / CurrencyConvertionPesos;
            decimal allAlbumsTotalPrice = totalEuropeAlbumPriceInLeva + totalNorthAmericaAlbumPriceInLeva + totalSouthAmericaAlbumPriceInLeva;
            decimal producerCut = ThirtyFivePercent * allAlbumsTotalPrice;
            decimal allAlbumsPriceWithProducerCut = allAlbumsTotalPrice - producerCut;
            decimal allAlbumsPriceWithTaxes = allAlbumsPriceWithProducerCut - TwentyPercent * allAlbumsPriceWithProducerCut;
            decimal concertsProfit = numberOfConcertsDuringTour * concertProfitInEuro * CurrencyConvertionEuro;

            if (concertsProfit > 100000)
            {
                concertsProfit = concertsProfit - FifteenPercent * concertsProfit;
            }

            if (allAlbumsPriceWithTaxes > concertsProfit)
            {
                Console.WriteLine("Let's record some songs! They'll bring us {0:0.00}lv.", allAlbumsPriceWithTaxes);
            }
            else
            {
                Console.WriteLine("On the road again! We'll see the world and earn {0:0.00}lv.", concertsProfit);
            }
        }
    }
}
