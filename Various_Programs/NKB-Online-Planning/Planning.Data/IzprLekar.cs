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
    
    public partial class IzprLekar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IzprLekar()
        {
            this.IzprLekarPS = new HashSet<IzprLekarPS>();
        }
    
        public decimal IzprLekarId { get; set; }
        public string IzprLekarUIN { get; set; }
        public string IzprLekarIme { get; set; }
        public bool IzprLekarNevidim { get; set; }
        public bool IzprLekarOtNZOK { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzprLekarPS> IzprLekarPS { get; set; }
    }
}