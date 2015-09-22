using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileNameOperations.GetFileExtension("example"));
            Console.WriteLine(FileNameOperations.GetFileExtension("example.pdf"));
            Console.WriteLine(FileNameOperations.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileNameOperations.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileNameOperations.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileNameOperations.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}", CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", CalcDistance3D(5, 2, -1, 3, -6, 4));

            PointOperations.Width = 3;
            PointOperations.Height = 4;
            PointOperations.Depth = 5;
            Console.WriteLine("Volume = {0:f2}", PointOperations.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", PointOperations.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", PointOperations.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", PointOperations.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", PointOperations.CalcDiagonalYZ());
        }

        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            return distance;
        }
    }
}
