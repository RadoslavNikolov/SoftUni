using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    [Route("[controller]")]
    public class AboutController : Controller
    {
        [Route("")]
        public string Phone()
        {
            return "+1-555-555-555-555";
        }

        [Route("[action]")]
        public string Country()
        {
            return "Bulgaria";
        }
    }
}
