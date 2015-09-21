using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GravitationOnTheMoon
{
    class GravitationOnTheMoon
    {
        static void Main(string[] args)
        {
            Console.Write("Enter weight: ");
            double weightOnEarth = double.Parse(Console.ReadLine());
            double weightOnMoon = weightOnEarth * 0.17;
            Console.WriteLine("Weight on the Moon: " + weightOnMoon);
        }
    }
}
