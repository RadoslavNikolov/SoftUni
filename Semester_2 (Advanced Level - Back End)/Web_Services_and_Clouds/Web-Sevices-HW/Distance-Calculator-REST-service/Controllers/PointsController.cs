namespace Distance_Calculator_REST_service.Controllers
{
    using System;
    using System.Web.Http;

    public class PointsController : ApiController
    {

        [HttpGet]
        [Route("api/points/distance")]
        public IHttpActionResult Distance(int startX, int startY, int endX, int endY)
        {
            var distance =
                Math.Sqrt((startX - endX) * (startX - endX) +
                          (startY - endY) * (startY - endY));

            return this.Ok(distance);
        }

        [HttpPost]
        [Route("api/points/dist")]
        public IHttpActionResult Dist(int startX, int startY, int endX, int endY)
        {
            var distance =
                Math.Sqrt((startX - endX) * (startX - endX) +
                          (startY - endY) * (startY - endY));

            return this.Ok(distance);
        }
    }
}
