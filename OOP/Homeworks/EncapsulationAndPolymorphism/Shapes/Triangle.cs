using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shapes
{
    class Triangle : BasicShape
    {
        public Triangle(double sideA, double sideB, double sideC)
            : base(sideA, sideB)
        {
            this.SideC = sideC;
        }

        public double SideC { get; set; }

        public override double CalculateArea()
        {
            double halfPerimeter = (this.Width + this.Height + this.SideC) / 2;
            double triangleArea = Math.Sqrt(halfPerimeter * (halfPerimeter - this.Width) * (halfPerimeter - this.Height) *
                (halfPerimeter - this.SideC));
            return triangleArea;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = this.Width + this.Height + this.SideC;
            return perimeter;
        }
    }
}
