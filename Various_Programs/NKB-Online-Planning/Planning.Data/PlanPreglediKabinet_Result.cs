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
    
    public partial class PlanPreglediKabinet_Result
    {
        public decimal PlanID { get; set; }
        public decimal PacientID { get; set; }
        public decimal ZvenoID { get; set; }
        public string PlanZap { get; set; }
        public System.DateTime PlanPrData { get; set; }
        public Nullable<int> PlanPrIsPlaniran { get; set; }
        public Nullable<int> PlanPrIsSpeshen { get; set; }
        public Nullable<int> PlanIsPriem { get; set; }
        public Nullable<int> PlanIsIzpalneno { get; set; }
        public Nullable<int> PlanIsDublirano { get; set; }
        public string PacFullName { get; set; }
        public Nullable<bool> PacIsVip { get; set; }
        public Nullable<int> Disp { get; set; }
    }
}
