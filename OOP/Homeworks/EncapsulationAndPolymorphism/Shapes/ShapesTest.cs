using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shapes
{
    class ShapesTest
    {
        static void Main(string[] args)
        {
            var shapes = new BasicShape[]
            {
                new Triangle(5, 13, 9),
                new Triangle(3.5, 4.2, 5.7),
                new Rectangle(5, 12),
                new Rectangle(8.3, 3.4),
                new Circle(2),
                new Circle(4.1)
            };
            foreach (var shape in shapes)
            {
                string shapeType = shape.GetType().Name;
                Console.WriteLine("Shape: " + shapeType + ": Area: " + shape.CalculateArea() + "; Perimeter: " + shape.CalculatePerimeter());
            }
        }
    }
}
