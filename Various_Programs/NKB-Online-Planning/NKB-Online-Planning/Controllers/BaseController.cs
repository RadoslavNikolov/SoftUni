namespace NKB_Online_Planning.Controllers
{
    using System.Web.Http;
    using Planning.Data;
    using Security;
    using Utils;

    [RequireHttps]
    [HmacAuthentication]
    public class BaseController : ApiController
    {
        public BaseController()
            : this(new BISEntities())
        {          
        }

        public BaseController(BISEntities bisData)
        {
            this.BisData = bisData;
        }

        public BISEntities BisData { get; set; }
    }
}
