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
    
    public partial class DispDosie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DispDosie()
        {
            this.DispGrupa = new HashSet<DispGrupa>();
            this.Pregled = new HashSet<Pregled>();
        }
    
        public decimal DispDosieID { get; set; }
        public Nullable<decimal> PacientID { get; set; }
        public Nullable<decimal> DDAmbList { get; set; }
        public Nullable<System.DateTime> DDOtData { get; set; }
        public Nullable<System.DateTime> DDDoData { get; set; }
        public Nullable<decimal> DDLekar { get; set; }
        public Nullable<decimal> DDBolest { get; set; }
        public Nullable<decimal> DDOtpisvane { get; set; }
        public bool DDDeleted { get; set; }
        public decimal DDRZOKID { get; set; }
        public Nullable<decimal> DDNomer { get; set; }
        public Nullable<decimal> DDSpec { get; set; }
        public string DDKodSpec { get; set; }
        public Nullable<decimal> DPID { get; set; }
        public Nullable<decimal> DDMKB { get; set; }
    
        public virtual Nomenklatura Nomenklatura { get; set; }
        public virtual Pacient Pacient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DispGrupa> DispGrupa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pregled> Pregled { get; set; }
    }
}
