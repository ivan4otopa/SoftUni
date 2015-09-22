using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abstraction
{
    class Circle : Figure
    {
        private double radius;

        public Circle()
        {
        }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius 
        {
            get
            {
                return this.radius;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Radius must be a positive number.");
                }

                this.radius = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
