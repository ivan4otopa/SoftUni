using DistanceCalculatorClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceCalculatorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new DistanceCalculatorServiceClient();
            double result = client.CalculateDistance(new Point(2, 4), new Point(3, 5));

            Console.WriteLine(result);

            client.Close();
        }
    }
}
