namespace PlayWithToList
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    class PlayWithToList
    {
        static void Main(string[] args)
        {
            var context = new AdsEntities();

            context.Database.ExecuteSqlCommand("CHECKPOINT; DBCC DROPCLEANBUFFERS;");

            var nonOptimizedRunningTimes = new List<TimeSpan>();
            var optimizedRunningTimes = new List<TimeSpan>();
            var sw = new Stopwatch();
            
            sw.Start();

            for (int i = 0; i < 10; i++)
            {
                NonOptimizedQuery(context);
                nonOptimizedRunningTimes.Add(sw.Elapsed);
                sw.Restart();
            }

            for (int i = 0; i < 10; i++)
            {
                OptimizedQuery(context);
                optimizedRunningTimes.Add(sw.Elapsed);
                sw.Restart();
            }

            Console.WriteLine("NonOptimized: {0}", nonOptimizedRunningTimes.Average(ts => ts.TotalMilliseconds));
            Console.WriteLine("Optimized: {0}", optimizedRunningTimes.Average(ts => ts.TotalMilliseconds));
        }

        public static void NonOptimizedQuery(AdsEntities context)
        {
            var ads = context.Ads
                .ToList()
                .Where(a => a.AdStatus.Status == "Published")
                .Select(a => new
                {
                    a.Title,
                    a.Category,
                    a.Town,
                    a.Date
                })
                .ToList()
                .OrderBy(a => a.Date);
        }

        public static void OptimizedQuery(AdsEntities context)
        {
            var ads = context.Ads
                .Where(a => a.AdStatus.Status == "Published")
                .OrderBy(a => a.Date)
                .Select(a => new
                {
                    a.Title,
                    a.Category,
                    a.Town,
                })
                .ToList();
        }
    }
}
