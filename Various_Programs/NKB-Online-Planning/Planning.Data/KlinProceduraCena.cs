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
    
    public partial class KlinProceduraCena
    {
        public decimal KlinProCenaID { get; set; }
        public decimal KlinicnaProceduraID { get; set; }
        public System.DateTime KlinProCenaData { get; set; }
        public Nullable<decimal> KlinProCena { get; set; }
        public bool KlinProCenaIsLegloden { get; set; }
        public bool KlinProCenaIsParv { get; set; }
    
        public virtual KlinicnaProcedura KlinicnaProcedura { get; set; }
    }
}