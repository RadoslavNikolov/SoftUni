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
    
    public partial class DoctorCommission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DoctorCommission()
        {
            this.BList = new HashSet<BList>();
            this.BList1 = new HashSet<BList>();
            this.KpLechenie = new HashSet<KpLechenie>();
        }
    
        public decimal ID { get; set; }
        public string Name { get; set; }
        public bool Effective { get; set; }
        public decimal DoctorId { get; set; }
        public decimal DoctorId1 { get; set; }
        public Nullable<decimal> DoctorId2 { get; set; }
        public Nullable<decimal> DoctorId3 { get; set; }
        public Nullable<decimal> DoctorId4 { get; set; }
        public Nullable<bool> LKKType { get; set; }
        public Nullable<int> InitialDecisionNumber { get; set; }
        public int Specialnost { get; set; }
        public int Kind { get; set; }
        public Nullable<decimal> DoctorId5 { get; set; }
        public Nullable<decimal> DoctorId6 { get; set; }
        public Nullable<decimal> DoctorId7 { get; set; }
        public Nullable<decimal> DoctorId8 { get; set; }
        public Nullable<decimal> DoctorId9 { get; set; }
        public Nullable<decimal> DoctorId10 { get; set; }
        public Nullable<decimal> DoctorId11 { get; set; }
        public Nullable<int> SpecIdDoc { get; set; }
        public Nullable<int> SpecIdDoc1 { get; set; }
        public Nullable<int> SpecIdDoc2 { get; set; }
        public Nullable<int> SpecIdDoc3 { get; set; }
        public Nullable<int> SpecIdDoc4 { get; set; }
        public Nullable<int> SpecIdDoc5 { get; set; }
        public Nullable<int> SpecIdDoc6 { get; set; }
        public Nullable<int> SpecIdDoc7 { get; set; }
        public Nullable<int> SpecIdDoc8 { get; set; }
        public Nullable<int> SpecIdDoc9 { get; set; }
        public Nullable<int> SpecIdDoc10 { get; set; }
        public Nullable<int> SpecIdDoc11 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BList> BList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BList> BList1 { get; set; }
        public virtual Personal Personal { get; set; }
        public virtual Personal Personal1 { get; set; }
        public virtual Personal Personal2 { get; set; }
        public virtual Personal Personal3 { get; set; }
        public virtual Personal Personal4 { get; set; }
        public virtual Personal Personal5 { get; set; }
        public virtual Personal Personal6 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KpLechenie> KpLechenie { get; set; }
        public virtual Personal Personal7 { get; set; }
        public virtual Personal Personal8 { get; set; }
        public virtual Personal Personal9 { get; set; }
        public virtual Personal Personal10 { get; set; }
        public virtual Personal Personal11 { get; set; }
    }
}