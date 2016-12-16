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
    
    public partial class IzsLAB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IzsLAB()
        {
            this.Antro_pok = new HashSet<Antro_pok>();
            this.IzsLABINRDanni = new HashSet<IzsLABINRDanni>();
            this.MikrobiologichnoIzsledvane = new HashSet<MikrobiologichnoIzsledvane>();
            this.OrderEntry = new HashSet<OrderEntry>();
            this.Usluga = new HashSet<Usluga>();
        }
    
        public decimal LabID { get; set; }
        public System.DateTime LabDataChas { get; set; }
        public decimal LabKamOtch { get; set; }
        public string LabNo { get; set; }
        public string LabNoMat { get; set; }
        public decimal LabFinans { get; set; }
        public string LabVid { get; set; }
        public string LabVidDop { get; set; }
        public Nullable<decimal> LabVidMKB { get; set; }
        public string LabMKBDop { get; set; }
        public decimal LabMiasto { get; set; }
        public Nullable<decimal> LabLekar { get; set; }
        public bool LabSpeshno { get; set; }
        public Nullable<decimal> LabZapl { get; set; }
        public Nullable<decimal> LabNasZveno { get; set; }
        public Nullable<decimal> LabNasVun { get; set; }
        public string LabNasDoc { get; set; }
        public Nullable<System.DateTime> LabNasData { get; set; }
        public Nullable<System.DateTime> LabMaterData { get; set; }
        public Nullable<decimal> LabNasDiag { get; set; }
        public string LabNasDrugi { get; set; }
        public string LabRezultat { get; set; }
        public Nullable<decimal> LabDiag { get; set; }
        public string LabDopDiag { get; set; }
        public Nullable<decimal> LabDiagDop { get; set; }
        public string LabDrugi { get; set; }
        public string LabZak { get; set; }
        public Nullable<bool> LabProfilakt { get; set; }
        public Nullable<bool> LabDispanser { get; set; }
        public decimal PacID { get; set; }
        public Nullable<decimal> BolID { get; set; }
        public Nullable<decimal> NasID { get; set; }
        public string LabProt { get; set; }
        public string LabProtRes { get; set; }
        public Nullable<System.DateTime> LabDataChasKrai { get; set; }
        public Nullable<decimal> LabVidMat { get; set; }
        public Nullable<decimal> LabSpecDiag { get; set; }
        public string LabNomList { get; set; }
        public int LabVidBroi { get; set; }
        public Nullable<decimal> KpLechenieID { get; set; }
        public decimal LabLisResultId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Antro_pok> Antro_pok { get; set; }
        public virtual BolnichnoLechenie BolnichnoLechenie { get; set; }
        public virtual Diagnoza Diagnoza { get; set; }
        public virtual Nomenklatura Nomenklatura { get; set; }
        public virtual Nomenklatura Nomenklatura1 { get; set; }
        public virtual Personal Personal { get; set; }
        public virtual Zveno Zveno { get; set; }
        public virtual Zveno Zveno1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsLABINRDanni> IzsLABINRDanni { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MikrobiologichnoIzsledvane> MikrobiologichnoIzsledvane { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderEntry> OrderEntry { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usluga> Usluga { get; set; }
    }
}
