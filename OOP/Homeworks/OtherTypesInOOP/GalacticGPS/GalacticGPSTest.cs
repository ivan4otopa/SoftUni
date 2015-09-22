using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalacticGPS.Enums;
using GalacticGPS.Structs;

namespace GalacticGPS
{
    class GalacticGPSTest
    {
        static void Main(string[] args)
        {
            Location home = new Location(18.037986, 28.870097, Planet.Earth);
            Console.WriteLine(home);
        }
    }
}
