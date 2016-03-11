namespace EventsInGivenDateRange
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;

    using Wintellect.PowerCollections;

    class EventsInGivenDateRange
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var events = new OrderedMultiDictionary<DateTime, string>(true);
            int linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                string eventEntry = Console.ReadLine();
                var eventTokens = eventEntry.Split('|');
                string eventName = eventTokens[0].Trim();

                DateTime eventDate = DateTime.Parse(eventTokens[1].Trim());

                events.Add(eventDate, eventName);
            }

            var dateRanges = new Dictionary<DateTime, DateTime>();
            int rangesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < rangesCount; i++)
            {
                string rangeEntry = Console.ReadLine();
                var rangeTokens = rangeEntry.Split('|');

                DateTime startDate = DateTime.Parse(rangeTokens[0].Trim());
                DateTime endDate = DateTime.Parse(rangeTokens[1].Trim());

                dateRanges.Add(startDate, endDate);
            }

            foreach (var range in dateRanges)
            {
                var eventsInRange = events.Range(range.Key, true, range.Value, true);

                Console.WriteLine(eventsInRange.KeyValuePairs.Count);

                foreach (var eventName in eventsInRange.Values)
                {
                    Console.WriteLine("{0} | {1}", eventName, range.Key);
                }
            }
        }
    }
}
