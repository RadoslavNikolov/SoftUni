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

    public class NomenclaturesController : BaseController
    {
        [HttpGet]
        [ActionName("allcitizenships")]
        public async Task<HttpResponseMessage> GetAllCitizenShips()
        {
            const int citizenshipNomenclaturePostid = 355;

            var nomenclature = this.BisData.Nomenklatura
                .FirstOrDefault(n => n.NomPostID == citizenshipNomenclaturePostid);

            if (nomenclature == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound, "Invalid citizenship nomenclature");
            }

            var citizenships = await this.BisData
                .Nomenklatura
                .Where(n => n.NomenklaturaSelfID == nomenclature.NomenklaturaID)
                .Select(n => new
                {
                    Id = (int)n.NomenklaturaID,
                    NomenclatureName = n.NomIme
                })
                .ToListAsync();

            if (citizenships.Count == 0)
            {
                return this.Request.CreateResponse(HttpStatusCode.NoContent, "No citizenships found");
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, citizenships);
        }


        [HttpGet]
        [ActionName("allcountries")]
        public async Task<HttpResponseMessage> GetAllCountries()
        {
            const int countriesNomSelfId = 1142;

            var countries = await this.BisData.Nomenklatura
                .Where(c => c.NomenklaturaSelfID == countriesNomSelfId)
                .Select(c => new
                {
                    Id = (int)c.NomenklaturaID,
                    CountryName = c.NomIme
                })
                .ToListAsync();

            if (countries.Count == 0)
            {
                return this.Request.CreateResponse(HttpStatusCode.NoContent, "No countries found");
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, countries);
        }


        [HttpGet]
        [ActionName("allresidences")]
        public async Task<HttpResponseMessage> GetAllResidences()
        {
            const int residenceNomSelfId = 1162;

            var residences = await this.BisData.Nomenklatura
                .Where(c => c.NomenklaturaSelfID == residenceNomSelfId)
                .Select(c => new
                {
                    Id = (int)c.NomenklaturaID,
                    Residence = c.NomIme
                })
                .ToListAsync();

            if (residences.Count == 0)
            {
                return this.Request.CreateResponse(HttpStatusCode.NoContent, "No residences found");
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, residences);
        }
    }
}
