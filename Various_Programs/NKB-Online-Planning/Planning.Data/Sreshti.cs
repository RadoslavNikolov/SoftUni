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
    
    public partial class Sreshti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sreshti()
        {
            this.Sluchai = new HashSet<Sluchai>();
        }
    
        public decimal SreID { get; set; }
        public System.DateTime SreDataChas { get; set; }
        public bool SreIsKlinichna { get; set; }
        public bool SreIsLKK { get; set; }
        public string SreTema { get; set; }
        public string SreUchastvali { get; set; }
        public string SreProtocol { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sluchai> Sluchai { get; set; }
    }
}
