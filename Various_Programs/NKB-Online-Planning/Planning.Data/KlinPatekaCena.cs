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
    
    public partial class KlinPatekaCena
    {
        public decimal KlinPatCenaID { get; set; }
        public decimal KlinicnaPatekaID { get; set; }
        public System.DateTime KlinPatCenaData { get; set; }
        public Nullable<decimal> KlinPatCena { get; set; }
        public bool KlinPatCenaIsLegloden { get; set; }
        public bool KlinPatCenaIsParv { get; set; }
    
        public virtual KlinicnaPateka KlinicnaPateka { get; set; }
    }
}
