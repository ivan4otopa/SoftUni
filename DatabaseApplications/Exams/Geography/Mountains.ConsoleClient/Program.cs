namespace Mountains.ConsoleClient
{
    using Data;
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new MountainsContext();

            //6.ListMountainsAndTheirCountriesAndPeaks
            //var mountains = context.Mountains
            //    .Select(m => new
            //    {
            //        m.Name,
            //        Countries = m.Countries
            //            .Select(c => c.CountryName),
            //        Peaks = m.Peaks
            //            .Select(p => p.Name)
            //    });

            //foreach (var mountain in mountains)
            //{
            //    Console.WriteLine("Mountain: {0}\nCountries: {1}\nPeaks: {2}", mountain.Name, string.Join(", ", mountain.Countries),
            //        string.Join(", ", mountain.Peaks));
            //}
        }
    }
}
