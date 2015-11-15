namespace Restaurants.Services.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Results;
    using Data;
    using Data.UnitOfWork;
    using Providers;

    public class BaseApiController : ApiController
    {
        public BaseApiController()
            : this(new RestaurantData(RestaurantsContext.Create()), new AspNetUserProvider())
        {
        }

        public BaseApiController(IRestaurantData data, IUserProvider userProvider)
        {
            this.Db = data;
            this.UserProvider = userProvider;
        }


        public IRestaurantData Db { get; set; }

        protected IUserProvider UserProvider { get; set; }

        protected ResponseMessageResult CreateResponseMessage(HttpStatusCode statusCode, string message)
        {
            return this.ResponseMessage(this.Request.CreateResponse(statusCode,
                new
                {
                    Message = message
                }));
        } 
    }
}