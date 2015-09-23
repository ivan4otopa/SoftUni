namespace ShowDataFromRelatedTables
{
    using System;
    using System.Linq;
    using System.Data.Entity;
    using System.Diagnostics;

    class ShowDataFromRelatedTables
    {
        static void Main(string[] args)
        {
            var context = new AdsEntities();
            var sw = new Stopwatch();

            sw.Start();
            AdsWithoutInclude(context);
            Console.WriteLine("Without Include: {0}", sw.Elapsed);
            sw.Restart();
            AdsWithInclude(context);
            Console.WriteLine("With Include: {0}", sw.Elapsed);
        }

        public static void AdsWithoutInclude(AdsEntities context)
        {
            var ads = context.Ads;
            string withoutInclude = "";

            foreach (var ad in ads)
            {
                withoutInclude += string.Format("Ad Title: {0}, Ad Status: {1}, Ad Category: {2}, Ad Town: {3}, Ad User: {4}", ad.Title,
                    ad.AdStatus.Status, (ad.Category == null ? "No Category" : ad.Category.Name),
                    (ad.Town == null ? "No Town" : ad.Town.Name), ad.AspNetUser.Name);
            }
        }

        public static void AdsWithInclude(AdsEntities context)
        {
            string withInclude = "";

            foreach (var ad in context.Ads
                .Include(a => a.AdStatus)
                .Include(a => a.Category)
                .Include(a => a.Town)
                .Include(a => a.AspNetUser))
            {
                withInclude = string.Format("Ad Title: {0}, Ad Status: {1}, Ad Category: {2}, Ad Town: {3}, Ad User: {4}", ad.Title,
                    ad.AdStatus.Status, (ad.Category == null ? "No Category" : ad.Category.Name),
                    (ad.Town == null ? "No Town" : ad.Town.Name), ad.AspNetUser.Name);
            }
        }
    }
}
