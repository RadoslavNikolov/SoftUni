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
    
    public partial class Praktika
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Praktika()
        {
            this.IzprLekarPS = new HashSet<IzprLekarPS>();
        }
    
        public decimal PraktikaID { get; set; }
        public string PraktikaKod { get; set; }
        public string PraktikaIme { get; set; }
        public bool PraktikaNevidim { get; set; }
        public bool PraktikaOtNZOK { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzprLekarPS> IzprLekarPS { get; set; }
    }
}
