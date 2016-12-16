using Planning.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public class DoctorModel
    {
        public int PersonalId { get; set; }

        public int SpecialityId { get; set; }

        public string Speciality { get; set; }

        public int? UnitId { get; set; }

        public string Unit { get; set; }

        public string DoctorTitle { get; set; }

        public string DoctorName { get; set; }

        public string DoctorUin { get; set; }

        public static Expression<Func<Personal,DoctorModel>> FromPersonal
        {
            get
            {
                return p => new DoctorModel
                {
                    PersonalId = (int)p.PersonalID,
                    SpecialityId = (int)p.SpecialnostPersonalID,
                    Speciality = p.SpecialnostPersonal.SpecPersIme,
                    UnitId = (int)p.ZvenoID,
                    Unit = p.Zveno.ZvenoIme,
                    DoctorTitle = p.PersZvanie,
                    DoctorName = p.PersIme,
                    DoctorUin = p.PersUIN
                };
            }
        }

    }
}
