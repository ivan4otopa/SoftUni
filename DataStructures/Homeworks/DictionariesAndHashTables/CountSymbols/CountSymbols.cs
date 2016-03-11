namespace CountSymbols
{
    using System;
    using System.Linq;

    using Dictionary;

    class CountSymbols
    {
        static void Main()
        {
            char[] symbols = Console.ReadLine().ToCharArray();
            var symbolsCount = new Dictionary<char, int>();

            foreach (var symbol in symbols)
            {
                if (!symbolsCount.ContainsKey(symbol))
                {
                    symbolsCount.Add(symbol, 0);
                }

                symbolsCount[symbol]++;
            }

            var sortedSymbolsCount = symbolsCount
                .OrderBy(sc => sc.Key);

            foreach (var symbolCount in sortedSymbolsCount)
            {
                Console.WriteLine("{0}: {1} time/s", symbolCount.Key, symbolCount.Value);
            }
        }
    }
}
