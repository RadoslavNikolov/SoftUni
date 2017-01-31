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
    
    public partial class IzsFNI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IzsFNI()
        {
            this.IzdNaprNZOK = new HashSet<IzdNaprNZOK>();
            this.OrderEntry = new HashSet<OrderEntry>();
        }
    
        public decimal FniID { get; set; }
        public System.DateTime FniDataChas { get; set; }
        public decimal FniKamOtch { get; set; }
        public string FniNo { get; set; }
        public decimal FniFinans { get; set; }
        public Nullable<decimal> FniVid { get; set; }
        public string FniVidDop { get; set; }
        public Nullable<decimal> FniVidMKB { get; set; }
        public string FniMKBDop { get; set; }
        public decimal FniMiasto { get; set; }
        public Nullable<decimal> FniLekar { get; set; }
        public bool FniSpeshno { get; set; }
        public Nullable<decimal> FniZapl { get; set; }
        public Nullable<decimal> FniNasZveno { get; set; }
        public Nullable<decimal> FniNasVun { get; set; }
        public string FniNasDoc { get; set; }
        public Nullable<System.DateTime> FniNasData { get; set; }
        public Nullable<decimal> FniNasDiag { get; set; }
        public string FniNasDrugi { get; set; }
        public string FniRezultat { get; set; }
        public decimal FniDiag { get; set; }
        public Nullable<decimal> FniDiagDop { get; set; }
        public string FniDopDiag { get; set; }
        public string FniDrugi { get; set; }
        public string FniZak { get; set; }
        public string FniVideoProt { get; set; }
        public string FniKaseta { get; set; }
        public bool FniProfilakt { get; set; }
        public bool FniDispanser { get; set; }
        public string FniProtSave { get; set; }
        public decimal PacID { get; set; }
        public Nullable<decimal> BolID { get; set; }
        public Nullable<decimal> PregledID { get; set; }
        public string FniProtRes { get; set; }
        public Nullable<decimal> KpLechenieID { get; set; }
    
        public virtual BolnichnoLechenie BolnichnoLechenie { get; set; }
        public virtual Diagnoza Diagnoza { get; set; }
        public virtual Diagnoza Diagnoza1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzdNaprNZOK> IzdNaprNZOK { get; set; }
        public virtual Nomenklatura Nomenklatura { get; set; }
        public virtual Nomenklatura Nomenklatura1 { get; set; }
        public virtual Personal Personal { get; set; }
        public virtual Usluga Usluga { get; set; }
        public virtual Zveno Zveno { get; set; }
        public virtual Zveno Zveno1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderEntry> OrderEntry { get; set; }
    }
}