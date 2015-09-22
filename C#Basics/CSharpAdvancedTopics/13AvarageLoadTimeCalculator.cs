using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13AverageLoadTimeCalculator
{
    class AverageLoadTimeCalculator
    {
        static void Main()
        {

            Console.WriteLine("Enter report: ");
            string line = Console.ReadLine();
            Dictionary<string, double> sites = new Dictionary<string, double>();
            Dictionary<string, int> counters = new Dictionary<string, int>();
            int counter = 1;
            while (line != string.Empty)
            {
                string[] list = line.Split(' ');
                string link = list[2];
                double loadTime = double.Parse(list[3]);
                if (!sites.Keys.Contains(link))
                {
                    sites[link] = loadTime; counters.Add(link, 1);
                }
                else
                {
                    counters[link] += 1;
                    sites[link] = sites[link] + loadTime;
                }
                line = Console.ReadLine();
            }
            foreach (string link in sites.Keys)
            {
                Console.WriteLine("{0} = {1:0.0000000}", link, sites[link] / counters[link]);
            }
        }
    }
}