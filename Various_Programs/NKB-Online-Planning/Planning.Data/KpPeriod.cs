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
    
    public partial class KpPeriod
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KpPeriod()
        {
            this.KpOtcheteni = new HashSet<KpOtcheteni>();
        }
    
        public decimal KpPeriodID { get; set; }
        public System.DateTime KpPeriodOtData { get; set; }
        public System.DateTime KpPeriodDoData { get; set; }
        public string KpPeriodIme { get; set; }
        public System.DateTime KppData { get; set; }
        public int KppDogovori { get; set; }
        public int KppCeni { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KpOtcheteni> KpOtcheteni { get; set; }
    }
}
