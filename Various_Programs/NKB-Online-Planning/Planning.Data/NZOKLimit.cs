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
    
    public partial class NZOKLimit
    {
        public decimal LimitID { get; set; }
        public System.DateTime OtData { get; set; }
        public System.DateTime DoData { get; set; }
        public Nullable<decimal> LimitKP { get; set; }
        public Nullable<decimal> LimitKPR01 { get; set; }
        public Nullable<decimal> LimitKPR05 { get; set; }
        public Nullable<decimal> LimitKPR09 { get; set; }
        public Nullable<decimal> LimitMed { get; set; }
        public Nullable<decimal> LimitImp { get; set; }
    }
}
