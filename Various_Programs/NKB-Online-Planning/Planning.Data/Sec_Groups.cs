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
    
    public partial class Sec_Groups
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sec_Groups()
        {
            this.Security = new HashSet<Security>();
        }
    
        public decimal GroupID { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Security> Security { get; set; }
    }
}
