using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;

namespace _10BeerTime
{
    class BeerTime
    {
        static void Main(string[] args)
        {
            CultureInfo enUS = new CultureInfo("en-US");
            DateTime time;
            DateTime startTime = DateTime.Parse("1:00 PM");
            DateTime endTime = DateTime.Parse("3:00 AM");
            Console.Write("Enter time: ");
            string dateString = Console.ReadLine();
            if (DateTime.TryParseExact(dateString, "h:mm tt", enUS, DateTimeStyles.None, out time))
            {
                if (time >= startTime || time < endTime)
                    Console.WriteLine("Result: beer time");
                else
                    Console.WriteLine("Result: non-beer time");
            }
            else
                Console.WriteLine("Invalid time");
        }
    }
}
