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
    
    public partial class IzprLekarPS
    {
        public decimal IzprLekarPSId { get; set; }
        public decimal IzprLekarId { get; set; }
        public Nullable<decimal> SpecialnostID { get; set; }
        public Nullable<decimal> PraktikaID { get; set; }
        public bool PSOtNZOK { get; set; }
    
        public virtual IzprLekar IzprLekar { get; set; }
        public virtual Praktika Praktika { get; set; }
    }
}
