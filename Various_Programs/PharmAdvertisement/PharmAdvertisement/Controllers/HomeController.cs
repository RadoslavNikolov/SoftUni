using PharmAdvertisement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmAdvertisement.Controllers
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using Data.Models;

    public class HomeController : Controller
    {
        private AdvertisementContext context = AdvertisementContext.Create();
        public ActionResult Index()
        {

            //var q = context.Diagnoses.FirstOrDefault().DiagnosisName;

            this.FillDb();

            ViewBag.Title = "Home Page";

            return View();
        }

        private void FillDb()
        {
            var sourceDt = this.GetInfoFromDb();

            ProcessData(sourceDt);
        }

        private void ProcessData(DataTable sourceDt)
        {
            //this.StepFirst(sourceDt);
            //this.StepSecond(sourceDt);

            //var sqlStr = @"select 
            //            d1.DiagnozaID,
            //         d1.DiagnozaSelfID, 
            //         d1.DiagIme,
            //         d1.DiagKod,
            //         d1.DiagIsInvisible,
            //         d1.DiagIsDiag,
            //         (Select DiagIme from Diagnoza d2 where d2.DiagnozaID = d1.DiagnozaSelfID) as parentName,
            //            d1.IsAKMP,
            //         d1.MkbAkmpMapping
            //            from Diagnoza d1 where d1.DiagnozaSelfID is Not null and d1.DiagKod is not null
            //            And(Select DiagKod from Diagnoza d2 where d2.DiagnozaID = d1.DiagnozaSelfID) Is Null";

            //var newSourceDt = this.GetInfoFromDb(sqlStr);
            //this.StepThird(newSourceDt);


            var sqlStr = @"select 
                        d1.DiagnozaID,
                     d1.DiagnozaSelfID, 
                     d1.DiagIme,
                     d1.DiagKod,
                     d1.DiagIsInvisible,
                     d1.DiagIsDiag,
                     (Select DiagIme from Diagnoza d2 where d2.DiagnozaID = d1.DiagnozaSelfID) as parentName,
                        d1.IsAKMP,
                     d1.MkbAkmpMapping
                        from Diagnoza d1 where d1.DiagnozaSelfID is Not null and d1.DiagKod is not null
                        And(Select DiagKod from Diagnoza d2 where d2.DiagnozaID = d1.DiagnozaSelfID) Is Not Null";

            var newSourceDt = this.GetInfoFromDb(sqlStr);
            this.StepFourth(newSourceDt);
        }

        private void StepFourth(DataTable sourceDt)
        {
            var tempContext = this.context.Diagnoses.Where(d => d.Parent != null && d.DiagnosisCode != null).ToList();

            var q = sourceDt.AsEnumerable()
                .Select(r => new Diagnosis
                {
                    DiagnosisName = r.Field<string>("DiagIme"),
                    IsDiag = r.Field<bool>("DiagIsDiag"),
                    IsAkmp = r.Field<bool>("IsAKMP"),
                    MkbAkmpMapping = r.Field<string>("MkbAkmpMapping"),
                    Parent = tempContext.FirstOrDefault(d => d.DiagnosisName.Equals(r.Field<string>("parentName")))
                });



            foreach (Diagnosis diagnosis in q)
            {
                this.context.Diagnoses.Add(diagnosis);
            }


            this.context.SaveChanges();
        }

        private void StepThird(DataTable sourceDt)
        {
            var tempContext = this.context.Diagnoses.Where(d => d.Parent != null && d.DiagnosisCode == null).ToList();

            var q = sourceDt.AsEnumerable()
                .Select(r => new Diagnosis
                {
                    DiagnosisName = r.Field<string>("DiagIme"),
                    IsDiag = r.Field<bool>("DiagIsDiag"),
                    IsAkmp = r.Field<bool>("IsAKMP"),
                    MkbAkmpMapping = r.Field<string>("MkbAkmpMapping"),
                    Parent = tempContext.FirstOrDefault(d => d.DiagnosisName.Equals(r.Field<string>("parentName")))
                });

            foreach (Diagnosis diagnosis in q)
            {
                this.context.Diagnoses.Add(diagnosis);
            }

            this.context.SaveChanges();
        }

        private void StepSecond(DataTable sourceDt)
        {
            var q = sourceDt.AsEnumerable()
                .Where(r => r.Field<decimal?>("DiagnozaSelfId") != null && r.Field<string>("DiagKod") == null)
                .Select(r => new Diagnosis
                {
                    DiagnosisName = r.Field<string>("DiagIme"),
                    IsDiag = r.Field<bool>("DiagIsDiag"),
                    IsAkmp = r.Field<bool>("IsAKMP"),
                    DiagnosisId = (int)r.Field<decimal>("DiagnozaSelfId")
                });

            var tempContext =
                    this.context.Diagnoses.Where(d => d.Parent == null && d.DiagnosisCode == null).ToList();

            foreach (Diagnosis diagnosis in q)
            {               
                var diagName = sourceDt.AsEnumerable()
                    .FirstOrDefault(x => x.Field<decimal>("DiagnozaId") == diagnosis.DiagnosisId)
                    .Field<string>("DiagIme");

                var parent = tempContext
                    .FirstOrDefault(d => d.DiagnosisName.Equals(diagName, StringComparison.InvariantCultureIgnoreCase));

                diagnosis.DiagnosisId = 0;
                diagnosis.Parent = parent;

                this.context.Diagnoses.Add(diagnosis);
            }

            this.context.SaveChanges();
        }

        private void StepFirst(DataTable sourceDt)
        {
            var q = sourceDt.AsEnumerable()
                .Where(r => r.Field<decimal?>("DiagnozaSelfId") == null && r.Field<string>("DiagKod") == null)
                .Select(r => new Diagnosis
                {
                    DiagnosisName = r.Field<string>("DiagIme"),
                    IsDiag = r.Field<bool>("DiagIsDiag"),
                    IsAkmp = r.Field<bool>("IsAKMP"),
                });

            foreach (Diagnosis diagnosis in q)
            {
                this.context.Diagnoses.Add(diagnosis);
            }

            this.context.SaveChanges();
        }

        private DataTable GetInfoFromDb(string sqlStr = null)
        {
            const string sqlConnStr = "Application Name=BISRadko;User ID=AppServer;Password=123;Data Source=192.168.12.11;Initial Catalog = NKB_1122";

            if (sqlStr == null)
            {
                sqlStr = "select * from Diagnoza";
            }

            DataTable dt = new DataTable();

            using (var conn = new SqlConnection(sqlConnStr))
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }

                using (var command = new SqlCommand(sqlStr, conn))
                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                }
            }

            return dt;
        }
    }
}
