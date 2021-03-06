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
    
    public partial class Pochinali
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pochinali()
        {
            this.PochinaliTakDonori = new HashSet<PochinaliTakDonori>();
            this.Diagnoza2 = new HashSet<Diagnoza>();
        }
    
        public decimal PochinalID { get; set; }
        public decimal PacientID { get; set; }
        public Nullable<decimal> PregledID { get; set; }
        public System.DateTime PocSmurtData { get; set; }
        public decimal PocSmurtMiasto { get; set; }
        public Nullable<decimal> PocSmurtZveno { get; set; }
        public bool PocSmurtOperacia { get; set; }
        public Nullable<decimal> PocSmurtDiagnoza { get; set; }
        public Nullable<decimal> PocSmurtDiagDop { get; set; }
        public string PocSmurtDopulDiag { get; set; }
        public string PocSmurtDrugiDanni { get; set; }
        public bool PocAutOsvoboden { get; set; }
        public Nullable<decimal> PocAutID { get; set; }
        public Nullable<System.DateTime> PocAutDataChas { get; set; }
        public string PocAutNomer { get; set; }
        public Nullable<decimal> PocAutIzvurshID { get; set; }
        public bool PocAutBiopsMat { get; set; }
        public bool PocAutOpMat { get; set; }
        public bool PocAutCitoMat { get; set; }
        public bool PocAutMicrobioIz { get; set; }
        public Nullable<decimal> PocAutDiagID { get; set; }
        public string PocAutDopulDiag { get; set; }
        public string PocAutPulnaDiag { get; set; }
        public string PocAutDiagSupostavka { get; set; }
        public string PocAutMacroscop { get; set; }
        public string PocAutHistolog { get; set; }
        public string PocAutEpikriza { get; set; }
        public string PocAutProtocol { get; set; }
        public Nullable<decimal> BLID { get; set; }
        public bool PocMozSmurt { get; set; }
        public bool PocDonor { get; set; }
    
        public virtual BolnichnoLechenie BolnichnoLechenie { get; set; }
        public virtual Diagnoza Diagnoza { get; set; }
        public virtual Diagnoza Diagnoza1 { get; set; }
        public virtual Nomenklatura Nomenklatura { get; set; }
        public virtual Pacient Pacient { get; set; }
        public virtual Personal Personal { get; set; }
        public virtual Pregled Pregled { get; set; }
        public virtual Zveno Zveno { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PochinaliTakDonori> PochinaliTakDonori { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diagnoza> Diagnoza2 { get; set; }
    }
}
