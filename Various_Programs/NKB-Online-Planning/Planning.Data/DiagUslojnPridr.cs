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
    
    public partial class DiagUslojnPridr
    {
        public decimal DiagUslojnPridrID { get; set; }
        public decimal DiagnozaID { get; set; }
        public decimal DiagUpDiagnozaID { get; set; }
        public decimal DiagUpSort { get; set; }
        public bool DiagUpIsInvisible { get; set; }
        public bool DiagUpIsPridruj { get; set; }
    
        public virtual Diagnoza Diagnoza { get; set; }
        public virtual Diagnoza Diagnoza1 { get; set; }
    }
}