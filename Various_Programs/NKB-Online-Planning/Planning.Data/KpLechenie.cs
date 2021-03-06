//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Planning.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class KpLechenie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KpLechenie()
        {
            this.Hemodializa = new HashSet<Hemodializa>();
            this.toCypro = new HashSet<toCypro>();
        }
    
        public decimal KpLechenieID { get; set; }
        public decimal PacientID { get; set; }
        public decimal KpNasOt { get; set; }
        public decimal KpNasRZOK { get; set; }
        public decimal KpNasZR { get; set; }
        public string KpNasLZ { get; set; }
        public string KpNasUIN { get; set; }
        public string KpNasLekarIme { get; set; }
        public string KpNasUINZam { get; set; }
        public bool KpNasZam { get; set; }
        public decimal KpNasKPro { get; set; }
        public bool KpNasSpeshno { get; set; }
        public System.DateTime KpNasData { get; set; }
        public decimal KpKPro { get; set; }
        public bool KpSpeshno { get; set; }
        public bool KpOtkaz { get; set; }
        public string KpOtkazPrichina { get; set; }
        public decimal KpDiag1 { get; set; }
        public Nullable<decimal> KpDiag1Dop { get; set; }
        public Nullable<decimal> KpDiag2 { get; set; }
        public Nullable<decimal> KpDiag2Dop { get; set; }
        public Nullable<decimal> KpProc { get; set; }
        public Nullable<decimal> KpPriemLekar { get; set; }
        public Nullable<decimal> KpLekLekar { get; set; }
        public Nullable<decimal> KpNachOtd { get; set; }
        public bool KpIzpalneno { get; set; }
        public Nullable<decimal> KpProc2 { get; set; }
        public Nullable<decimal> KpProc3 { get; set; }
        public bool KpNov { get; set; }
        public bool KpPeroralna { get; set; }
        public bool KpUsp { get; set; }
        public Nullable<decimal> DispDosieID { get; set; }
        public Nullable<decimal> KpListNo { get; set; }
        public bool KpOtdOtchet { get; set; }
        public bool KpProveren { get; set; }
        public Nullable<System.DateTime> KpDataKrai { get; set; }
        public Nullable<decimal> IntID { get; set; }
        public Nullable<decimal> BolID { get; set; }
        public bool KpPMS17 { get; set; }
        public Nullable<decimal> KpNo { get; set; }
        public Nullable<System.DateTime> KpProcDoneDate { get; set; }
        public Nullable<System.DateTime> KpProc2DoneDate { get; set; }
        public Nullable<System.DateTime> KpProc3DoneDate { get; set; }
        public bool IsRedirectToKP999 { get; set; }
        public Nullable<decimal> OD_LkkID { get; set; }
        public Nullable<int> OD_no_decision { get; set; }
        public Nullable<System.DateTime> OD_date_decision { get; set; }
        public Nullable<int> OD_height { get; set; }
        public Nullable<int> OD_weight { get; set; }
        public Nullable<decimal> OD_BSA { get; set; }
        public string OD_ECOG { get; set; }
        public Nullable<decimal> OD_HistoDiagId { get; set; }
        public string OD_imuno { get; set; }
        public string OD_Genetic { get; set; }
        public string OD_Staging { get; set; }
        public string OD_therapy { get; set; }
        public string OD_kursove { get; set; }
        public string OD_interval { get; set; }
        public string OD_evalafter { get; set; }
        public string OD_DecisionXML { get; set; }
        public string OD_EvaluationXML { get; set; }
        public Nullable<decimal> KpPlanID { get; set; }
        public string OD_OtherDiseases { get; set; }
        public string OD_Anamnesis { get; set; }
        public string OD_FairCondition { get; set; }
        public string OD_Regiment { get; set; }
        public Nullable<int> KpDiag3 { get; set; }
        public Nullable<int> KpDiag3Dop { get; set; }
        public string OD_DiagsAddInfoXML { get; set; }
    
        public virtual Diagnoza Diagnoza { get; set; }
        public virtual DoctorCommission DoctorCommission { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hemodializa> Hemodializa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<toCypro> toCypro { get; set; }
        public virtual PlaniranePregled PlaniranePregled { get; set; }
    }
}
