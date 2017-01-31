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
    
    public partial class Operacia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Operacia()
        {
            this.Anestezia = new HashSet<Anestezia>();
            this.Implantant = new HashSet<Implantant>();
            this.OperEKK = new HashSet<OperEKK>();
        }
    
        public decimal OperaciaID { get; set; }
        public decimal BolID { get; set; }
        public System.DateTime OperData { get; set; }
        public decimal OperFinansirane { get; set; }
        public string OperProtokol { get; set; }
        public decimal OperMiasto { get; set; }
        public Nullable<System.DateTime> OperVreme { get; set; }
        public decimal OperVid { get; set; }
        public decimal OperSpeshnost { get; set; }
        public decimal OperAnestezia { get; set; }
        public bool OperIsEKK { get; set; }
        public bool OperIsSaglasie { get; set; }
        public Nullable<decimal> OperLecProc1 { get; set; }
        public Nullable<decimal> OperLecProc2 { get; set; }
        public Nullable<decimal> OperLecProc5 { get; set; }
        public Nullable<decimal> OperLecProc4 { get; set; }
        public Nullable<decimal> OperDiagProc1 { get; set; }
        public Nullable<decimal> OperDiagProc2 { get; set; }
        public Nullable<decimal> OperDiagnoza { get; set; }
        public Nullable<decimal> OperHistolog { get; set; }
        public string OperDanni { get; set; }
        public decimal OperHirurg { get; set; }
        public Nullable<decimal> OperAsistent1 { get; set; }
        public Nullable<decimal> OperAsistent2 { get; set; }
        public Nullable<decimal> OperSestra1 { get; set; }
        public Nullable<decimal> OperSestra2 { get; set; }
        public bool OperIsBiopsia { get; set; }
        public string OperativenProt { get; set; }
        public string OperLP1Drugi { get; set; }
        public string OperLP2Drugi { get; set; }
        public string OperDP1Drugi { get; set; }
        public string OperDP2Drugi { get; set; }
        public string OperDiagDrugi { get; set; }
        public string OperHistDrugi { get; set; }
        public Nullable<decimal> OperUsluga { get; set; }
        public bool OperIsUsl { get; set; }
        public bool OperIsReop { get; set; }
        public string UslugiList { get; set; }
        public string OperEnd { get; set; }
        public Nullable<decimal> OperAnesteziolog { get; set; }
        public Nullable<decimal> OperAsistent3 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Anestezia> Anestezia { get; set; }
        public virtual BolnichnoLechenie BolnichnoLechenie { get; set; }
        public virtual Diagnoza Diagnoza { get; set; }
        public virtual Diagnoza Diagnoza1 { get; set; }
        public virtual Diagnoza Diagnoza2 { get; set; }
        public virtual Diagnoza Diagnoza3 { get; set; }
        public virtual Diagnoza Diagnoza4 { get; set; }
        public virtual Diagnoza Diagnoza5 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Implantant> Implantant { get; set; }
        public virtual Nomenklatura Nomenklatura { get; set; }
        public virtual Nomenklatura Nomenklatura1 { get; set; }
        public virtual Nomenklatura Nomenklatura2 { get; set; }
        public virtual Nomenklatura Nomenklatura3 { get; set; }
        public virtual Personal Personal { get; set; }
        public virtual Personal Personal1 { get; set; }
        public virtual Personal Personal2 { get; set; }
        public virtual Personal Personal3 { get; set; }
        public virtual Personal Personal4 { get; set; }
        public virtual Zveno Zveno { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OperEKK> OperEKK { get; set; }
    }
}