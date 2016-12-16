using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NKB_Online_Planning.Controllers
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using Planning.Model;

    public class DoctorsController : BaseController
    {

        [HttpGet]
        [ActionName("all")]
        // GET api/Doctors/all
        public async Task<HttpResponseMessage> GetAll()
        {

            var doctors = await this.BisData.Personal
               .Where(p => p.PersIsLekar && !p.PersIsInvisible)
               .Select(DoctorModel.FromPersonal)
               .ToListAsync();

            if (doctors.Count == 0)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, doctors);
        }
    }
}
