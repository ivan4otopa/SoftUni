using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplicationDistanceCalculator.Controllers
{
    public class PointsController : ApiController
    {
        public double Get(int startX, int startY, int endX, int endY)
        {
            return Math.Sqrt(Math.Pow(startX - endX, 2) + Math.Pow(startY - endY, 2));
        }
    }
}
