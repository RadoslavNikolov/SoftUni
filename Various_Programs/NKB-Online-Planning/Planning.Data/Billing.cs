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
    
    public partial class Billing
    {
        public decimal BillingID { get; set; }
        public Nullable<decimal> PacientID { get; set; }
        public Nullable<int> BillingType { get; set; }
        public string BillingIme { get; set; }
        public Nullable<decimal> BillingCena { get; set; }
        public Nullable<decimal> BillingBroi { get; set; }
        public string BillingDates { get; set; }
        public Nullable<System.DateTime> BillingDate { get; set; }
        public Nullable<decimal> BillingAvans { get; set; }
        public Nullable<decimal> MedCentar { get; set; }
    
        public virtual Pacient Pacient { get; set; }
    }
}
