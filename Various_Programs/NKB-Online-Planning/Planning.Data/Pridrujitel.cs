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
    
    public partial class Pridrujitel
    {
        public decimal PridrujitelID { get; set; }
        public decimal BolId { get; set; }
        public string PridIme { get; set; }
        public string PridEGN { get; set; }
        public string PridAdres { get; set; }
        public System.DateTime PridOtData { get; set; }
        public Nullable<System.DateTime> PridDoData { get; set; }
        public bool PridIsENC { get; set; }
    
        public virtual BolnichnoLechenie BolnichnoLechenie { get; set; }
    }
}
