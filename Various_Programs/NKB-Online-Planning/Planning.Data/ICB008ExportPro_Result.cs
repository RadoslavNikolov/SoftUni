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
    
    public partial class ICB008ExportPro_Result
    {
        public int OType { get; set; }
        public Nullable<decimal> MyID { get; set; }
        public Nullable<decimal> BolID { get; set; }
        public string PART { get; set; }
        public string SR_CODE { get; set; }
        public int SR_CNT { get; set; }
        public System.DateTime SR_STARTTIME { get; set; }
        public Nullable<System.DateTime> SR_ENDTIME { get; set; }
        public Nullable<System.DateTime> AN_STARTTIME { get; set; }
        public Nullable<System.DateTime> AN_ENDTIME { get; set; }
        public int SR_ISCOMPL { get; set; }
        public string CODESURG1 { get; set; }
        public string CODESURG2 { get; set; }
        public string CODESURG3 { get; set; }
        public string CODEANEST { get; set; }
        public Nullable<decimal> SR_Nurse { get; set; }
        public string SR_EKK { get; set; }
        public Nullable<decimal> AN_Nurse { get; set; }
        public string EmergType { get; set; }
        public string AN_TYPE { get; set; }
        public string AN_Cover { get; set; }
        public string AN_Drug { get; set; }
        public Nullable<int> IsInOperRoom { get; set; }
        public int IsReOper { get; set; }
        public int IsOperation { get; set; }
        public string SR_Complex { get; set; }
    }
}
