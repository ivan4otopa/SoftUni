using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shapes
{
    abstract class BasicShape : IShape
    {
        public BasicShape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
        public double Width { get; set; }
        public double Height { get; set; }
        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
    }
}
