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
    
    public partial class Security
    {
        public decimal SecurityID { get; set; }
        public Nullable<decimal> GroupId { get; set; }
        public Nullable<decimal> ModuleID { get; set; }
        public Nullable<bool> R { get; set; }
        public Nullable<bool> W { get; set; }
        public Nullable<bool> D { get; set; }
    
        public virtual Sec_Groups Sec_Groups { get; set; }
    }
}