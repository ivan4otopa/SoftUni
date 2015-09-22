using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shapes
{
    class Circle : BasicShape
    {
        public Circle(double radius)
            : base(radius, 0)
        {
        }

        public override double CalculateArea()
        {
            double area = Math.PI * this.Width * this.Width;
            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Width;
            return perimeter;
        }
    }
}
