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
    
    public partial class IzsIP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IzsIP()
        {
            this.Anestezia = new HashSet<Anestezia>();
            this.Antro_pok = new HashSet<Antro_pok>();
            this.Implantant = new HashSet<Implantant>();
            this.IzsIP_Res = new HashSet<IzsIP_Res>();
        }
    
        public decimal IpID { get; set; }
        public System.DateTime IpDataChas { get; set; }
        public Nullable<System.DateTime> IpProd { get; set; }
        public decimal IpKamOtch { get; set; }
        public string IpNo { get; set; }
        public decimal IpFinans { get; set; }
        public Nullable<bool> IpDopZOF { get; set; }
        public Nullable<decimal> IpVid { get; set; }
        public string IpVidDop { get; set; }
        public Nullable<decimal> IpMKB { get; set; }
        public string IpMKBDop { get; set; }
        public decimal IpMiasto { get; set; }
        public Nullable<decimal> IpLekar1 { get; set; }
        public Nullable<decimal> IpLekar2 { get; set; }
        public string IpEkip { get; set; }
        public bool IpSpeshno { get; set; }
        public Nullable<decimal> IpNasZveno { get; set; }
        public Nullable<decimal> IpNasVun { get; set; }
        public string IpNasDoc { get; set; }
        public Nullable<System.DateTime> IpNasData { get; set; }
        public Nullable<decimal> IpNasDiag { get; set; }
        public string IpNasDrugi { get; set; }
        public string IpPrem { get; set; }
        public Nullable<bool> IpEdnom { get; set; }
        public Nullable<System.DateTime> IpRentgenTime { get; set; }
        public Nullable<decimal> IpKontVid { get; set; }
        public string IpKontKol { get; set; }
        public string ipMedik { get; set; }
        public decimal IpDiag { get; set; }
        public string IpDopDiag { get; set; }
        public string IpDrugi { get; set; }
        public string IpUsloj { get; set; }
        public string IpZak { get; set; }
        public string IpCDNo { get; set; }
        public string IpProtSave { get; set; }
        public Nullable<decimal> BolID { get; set; }
        public decimal PacID { get; set; }
        public Nullable<decimal> IpLekar3 { get; set; }
        public Nullable<decimal> IpRoDoza { get; set; }
        public Nullable<decimal> IpMERoDoza { get; set; }
        public string IpVidLesia { get; set; }
        public Nullable<int> IpMKB2 { get; set; }
        public Nullable<int> IpMKB3 { get; set; }
        public string IpMKBDop2 { get; set; }
        public string IpMKBDop3 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Anestezia> Anestezia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Antro_pok> Antro_pok { get; set; }
        public virtual BolnichnoLechenie BolnichnoLechenie { get; set; }
        public virtual Diagnoza Diagnoza { get; set; }
        public virtual Diagnoza Diagnoza1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Implantant> Implantant { get; set; }
        public virtual Nomenklatura Nomenklatura { get; set; }
        public virtual Nomenklatura Nomenklatura1 { get; set; }
        public virtual Nomenklatura Nomenklatura2 { get; set; }
        public virtual Personal Personal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsIP_Res> IzsIP_Res { get; set; }
        public virtual Zveno Zveno { get; set; }
        public virtual Zveno Zveno1 { get; set; }
    }
}