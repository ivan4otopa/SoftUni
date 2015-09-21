using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rectangles
{
    class Rectangles
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter rectangle width and height.");
            Console.Write("Width: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine("Perimeter: " + ((width * 2) + (height * 2)));
            Console.WriteLine("Area: " + (width * height));
        }
    }
}
