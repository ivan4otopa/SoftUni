using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DistanceCalculatorService
{
    public class DistanceCalculatorService : IDistanceCalculatorService
    {
        public double CalculateDistance(Point firstPoint, Point secondPoint)
        {
            return Math.Sqrt(Math.Pow(firstPoint.X - firstPoint.Y, 2) + Math.Pow(secondPoint.X - secondPoint.Y, 2));
        }
    }
}
