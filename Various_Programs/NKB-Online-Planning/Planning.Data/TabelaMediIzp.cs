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
    
    public partial class TabelaMediIzp
    {
        public decimal TMIId { get; set; }
        public decimal TMId { get; set; }
        public decimal OrdEId { get; set; }
        public string TMISignatura { get; set; }
        public Nullable<bool> TMIVkl { get; set; }
        public Nullable<System.DateTime> printed { get; set; }
    
        public virtual OrderEntry OrderEntry { get; set; }
        public virtual TabelaMedi TabelaMedi { get; set; }
    }
}
