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
    
    public partial class NOIProverka
    {
        public decimal NOIProverkaID { get; set; }
        public System.DateTime NPData { get; set; }
        public string NPText { get; set; }
        public decimal NPStatusID { get; set; }
        public decimal PacientID { get; set; }
        public Nullable<decimal> AmbListID { get; set; }
        public Nullable<decimal> BolPriemID { get; set; }
        public Nullable<decimal> BolNapID { get; set; }
        public Nullable<decimal> BolPresID { get; set; }
        public string NPXml { get; set; }
    
        public virtual AmbList2005 AmbList2005 { get; set; }
        public virtual BolnichnoLechenie BolnichnoLechenie { get; set; }
        public virtual BolnichnoLechenie BolnichnoLechenie1 { get; set; }
        public virtual Pacient Pacient { get; set; }
    }
}
