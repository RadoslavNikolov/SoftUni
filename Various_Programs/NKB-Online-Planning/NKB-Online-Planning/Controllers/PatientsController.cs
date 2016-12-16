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
    using Planning.Data;
    using Planning.Model;
    using Planning.Model.InputModels;

    public class PatientsController : BaseController
    {
        [HttpGet]
        [ActionName("all")]
        // GET api/patients/all
        public async Task<HttpResponseMessage> GetAll()
        {
            var patients = await this.BisData
                .Pacient
                .Select(PatientModel.FromPatient)
                .ToListAsync();

            if (patients.Count == 0)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, patients);
        }


        [HttpGet]
        [ActionName("getbyid")]
        // GET api/patients/GetById/{id}
        public async Task<HttpResponseMessage> GetById([FromUri]int id)
        {
            var patient = await this.BisData
                .Pacient
                .Where(p => p.PacientID == id)
                .Select(PatientModel.FromPatient)
                .ToListAsync();

            if (patient.Count == 0)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, patient);
        }

        [HttpGet]
        [ActionName("getbyegn")]
        // GET api/patients/GetByEgn/{id}
        public async Task<HttpResponseMessage> GetByEgn([FromUri]string id)
        {
            var patient = await this.BisData
                .Pacient
                .Where(p => p.PacEGN.Equals(id, StringComparison.InvariantCultureIgnoreCase))
                .Select(PatientModel.FromPatient)
                .ToListAsync();

            if (patient.Count == 0)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, patient);
        }


        [HttpPost]
        public async Task<HttpResponseMessage> PostPatient([FromBody] PatientInputModel model)
        {
            if (model == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, "No model!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid input model!");
            }


            Pacient patient = await this.BisData
                .Pacient
                .FirstOrDefaultAsync(p => p.PacEGN.Equals(model.Egn, StringComparison.InvariantCultureIgnoreCase));

            if (patient != null)
            {
                return this.Request.CreateResponse(HttpStatusCode.Found, patient);
            }


            patient = new Pacient
            {
                PacDataNaRegistracia = DateTime.Now,
                PacIme = model.FirstName,
                PacPrezime = model.Surname,
                PacFamilia = model.FamilyName,
                PacEGN = model.Egn,
                PacDataNaRajdane = DateTime.Now,
                PacIsENCh = false,
                PacIsJena = false,
                PacAdres = model.Address,     
                PacGrajdanstvo = model.CitizenShip,
                PacDarjava = model.Country,
                PacJitelNa = model.Residentship,
                PacIsVavJurnal = false,
                PacJurnalenNomer = string.Empty,
                PacIsZakluchen = false,
                PacMiastoNaReg = this.BisData.Nomenklatura.Where(n => n.NomPostID == 2092).Select(n => n.NomenklaturaID).First(),
                PacIsVIP = false,
                PacIsDarjavnaZOO = false,
                PacIsVunshen = false,
                PacZOsiguren = true            
            };

            this.BisData.SaveChanges();

            return this.Request.CreateResponse(HttpStatusCode.OK, patient);
        }

    }
}
