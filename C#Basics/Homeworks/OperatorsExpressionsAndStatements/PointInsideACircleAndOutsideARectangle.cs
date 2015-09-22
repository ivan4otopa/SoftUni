using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PointInsideACircleAndOutsideARectangle
{
    class PointInsideACircleAndOutsideARectangle
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter x and y coordinates: ");
            Console.Write("x: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("y: ");
            double y = double.Parse(Console.ReadLine());
            if (((x - 1) * (x - 1)) + ((y - 1) * (y - 1)) <= 1.5 * 1.5)
            {
                if (((x > -1) || (x < 5)) && (y <= 1))
                    Console.WriteLine("Inside K & outside of R: no");
                else if (((x > -1) || (x < 5)) && (y > 1))
                    Console.WriteLine("Inside K & outside of R: yes");
            }
            else
                Console.WriteLine("Inside of K & outside of R: no");
        }
    }
}
