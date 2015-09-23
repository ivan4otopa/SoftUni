using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DistanceCalculatorService
{
    [ServiceContract]
    public interface IDistanceCalculatorService
    {
        [OperationContract]
        double CalculateDistance(Point firstPoint, Point secondPoint);   
    }
}
