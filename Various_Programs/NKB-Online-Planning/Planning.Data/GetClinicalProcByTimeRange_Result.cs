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
    
    public partial class GetClinicalProcByTimeRange_Result
    {
        public decimal PacientID { get; set; }
        public decimal KPLechenieID { get; set; }
        public string KPCode { get; set; }
        public string KPName { get; set; }
        public decimal KPValue { get; set; }
        public System.DateTime KpNasData { get; set; }
        public Nullable<System.DateTime> KpDataKrai { get; set; }
        public string KpMKB { get; set; }
        public string MKB2 { get; set; }
        public Nullable<int> bPac { get; set; }
        public bool isKlinProcAPr { get; set; }
        public bool PacZOES { get; set; }
        public string PacEGN { get; set; }
        public string PacFullName { get; set; }
    }
}
