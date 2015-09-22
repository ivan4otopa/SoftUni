using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abstraction
{
    abstract class Figure
    {
        public Figure()
        {
        }

        public abstract double CalculatePerimeter();

        public abstract double CalculateSurface();
    }
}
