using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CohesionAndCoupling
{
    static class PointOperations
    {
        public static double Width { get; set; }
        public static double Height { get; set; }
        public static double Depth { get; set; }

        public static double CalcVolume()
        {
            double volume = Width * Height * Depth;
            return volume;
        }

        public static double CalcDiagonalXYZ()
        {
            double distance = Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2) + Math.Pow(Depth, 2));
            return distance;
        }

        public static double CalcDiagonalXY()
        {
            double distance = Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2));
            return distance;
        }

        public static double CalcDiagonalXZ()
        {
            double distance = Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Depth, 2));
            return distance;
        }

        public static double CalcDiagonalYZ()
        {
            double distance = Math.Sqrt(Math.Pow(Height, 2) + Math.Pow(Depth, 2));
            return distance;
        }
    }
}
