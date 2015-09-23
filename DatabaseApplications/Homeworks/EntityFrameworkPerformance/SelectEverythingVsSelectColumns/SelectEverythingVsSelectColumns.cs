namespace SelectEverythingVsSelectColumns
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    class SelectEverythingVsSelectColumns
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
                SelectAllFromAds(context);
                nonOptimizedRunningTimes.Add(sw.Elapsed);
                sw.Restart();
            }

            for (int i = 0; i < 10; i++)
            {
                SelectOnlyTitleFromAds(context);
                optimizedRunningTimes.Add(sw.Elapsed);
                sw.Restart();
            }

            Console.WriteLine(string.Join(", ", optimizedRunningTimes));

            Console.WriteLine("NonOptimized: {0}", nonOptimizedRunningTimes.Average(ts => ts.TotalMilliseconds));
            Console.WriteLine("Optimized: {0}", optimizedRunningTimes.Average(ts => ts.TotalMilliseconds));
        }

        public static void SelectAllFromAds(AdsEntities context)
        {
            string adsTitles = "";
            var ads = context.Ads;

            foreach (var ad in ads)
            {
                adsTitles += string.Format("Ad Title: {0}", ad.Title);
            }
        }

        public static void SelectOnlyTitleFromAds(AdsEntities context)
        {
            string adsTitles = "";
            var ads = context.Ads
                .Select(a => a.Title);

            foreach (var ad in ads)
            {
                adsTitles += string.Format("Ad Title: {0}", ad);
            }
        }
    }
}
