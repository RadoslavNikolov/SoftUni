using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    using Data;
    using System.Linq.Expressions;

    public class PatientModel
    {
        public int? Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string FamilyName { get; set; }

        public string Egn { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime RegisterTime { get; set; }

        public string Address { get; set; }

        public Boolean PatientIsEnch { get; set; } = false;

        public string PassportNumber { get; set; }

        public bool HasMedicalInsurance { get; set; }

        public static Expression<Func<Pacient, PatientModel>> FromPatient
        {
            get
            {
              return p =>
                new PatientModel
                {
                    Id = (int)p.PacientID,
                    FirstName = p.PacIme,
                    Surname = p.PacPrezime,
                    FamilyName = p.PacFamilia,
                    Egn = p.PacEGN,
                    BirthDate = p.PacDataNaRajdane,
                    PatientIsEnch = p.PacIsENCh,
                    PassportNumber = p.PacLicnaKarta,
                    HasMedicalInsurance = p.PacZOsiguren,
                    Address = p.PacAdres,
                    RegisterTime = p.PacDataNaRegistracia
                };
            }
        }
    }
}
