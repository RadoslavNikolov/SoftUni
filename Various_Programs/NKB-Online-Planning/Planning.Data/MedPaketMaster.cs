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
    
    public partial class MedPaketMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MedPaketMaster()
        {
            this.MedPaketDetail = new HashSet<MedPaketDetail>();
        }
    
        public int MedPaketId { get; set; }
        public string MedPaketName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedPaketDetail> MedPaketDetail { get; set; }
    }
}
