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
    
    public partial class Diet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Diet()
        {
            this.BolnichnoLechenie = new HashSet<BolnichnoLechenie>();
            this.DietInfo = new HashSet<DietInfo>();
            this.DietOrder = new HashSet<DietOrder>();
            this.DietWardPersistance = new HashSet<DietWardPersistance>();
        }
    
        public int DietID { get; set; }
        public int DietContractID { get; set; }
        public string Name { get; set; }
        public int DurationInDays { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<decimal> BreakfastPrice { get; set; }
        public Nullable<decimal> LunchPrice { get; set; }
        public Nullable<decimal> DinnerPrice { get; set; }
        public Nullable<decimal> AllDayPrice { get; set; }
        public Nullable<System.DateTime> InactiveDate { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BolnichnoLechenie> BolnichnoLechenie { get; set; }
        public virtual DietContract DietContract { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DietInfo> DietInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DietOrder> DietOrder { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DietWardPersistance> DietWardPersistance { get; set; }
    }
}
