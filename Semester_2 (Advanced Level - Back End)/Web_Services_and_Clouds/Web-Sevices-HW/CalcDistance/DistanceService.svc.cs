using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CalcDistance
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IDistanceService
    {
        public double CalcDistance(float startPointX, float startPointY, float endPointX, float endPointY)
        {
            double distance =
                Math.Sqrt((startPointX - endPointX)*(startPointX - endPointX) +
                          (startPointY - endPointY)*(startPointY - endPointY));
            return distance;
        }
    }
}
