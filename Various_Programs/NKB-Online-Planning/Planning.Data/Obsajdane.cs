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
    
    public partial class Obsajdane
    {
        public decimal ObsID { get; set; }
        public System.DateTime ObsDataChas { get; set; }
        public decimal ObsMiasto { get; set; }
        public string ObsUch { get; set; }
        public string ObsReshenie { get; set; }
        public string ObsTerapia { get; set; }
        public decimal ObsDiag { get; set; }
        public string ObsDiagDrugi { get; set; }
        public Nullable<decimal> ObsDiagDop { get; set; }
        public string ObsDrugi { get; set; }
        public string ObsProtSave { get; set; }
        public decimal PacID { get; set; }
    
        public virtual Pacient Pacient { get; set; }
        public virtual Zveno Zveno { get; set; }
    }
}
