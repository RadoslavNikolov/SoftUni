using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BidSystem.RestServices.Controllers
{
    using System.Web.Http.Results;
    using Data;
    using Data.UnitOfWork;
    using Providers;

    public class BaseApiController : ApiController
    {



        public BaseApiController()
            : this(new BidSystemData(BidSystemDbContext.Create()), new AspNetUserProvider())
        {
        }

        public BaseApiController(IBidSystemData data, IUserProvider userProvider)
        {
            this.Db = data;
            this.UserProvider = userProvider;
        }


        public IBidSystemData Db { get; set; }

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
