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
    
    public partial class BolnichnoLechenieDop
    {
        public decimal BLDopID { get; set; }
        public decimal ID { get; set; }
        public Nullable<int> Grace1 { get; set; }
        public Nullable<int> Grace1MI { get; set; }
        public Nullable<int> Grace2 { get; set; }
        public Nullable<int> Grace2MI { get; set; }
        public Nullable<int> Crusade1 { get; set; }
        public Nullable<decimal> Crusade2 { get; set; }
        public string InfSagHir { get; set; }
        public Nullable<System.DateTime> BlDopData { get; set; }
        public Nullable<decimal> BlDopKPID { get; set; }
        public Nullable<decimal> BlDopImpID { get; set; }
        public Nullable<decimal> BlDopDii { get; set; }
        public Nullable<decimal> BlDopOP { get; set; }
        public Nullable<decimal> BlDopIP { get; set; }
        public Nullable<decimal> BlDopPro { get; set; }
        public Nullable<decimal> BlDopDiag { get; set; }
        public Nullable<decimal> Syntax { get; set; }
        public Nullable<decimal> EuroScore { get; set; }
        public Nullable<int> GFR { get; set; }
        public string BlDopParklinika { get; set; }
        public string BlDopTerShema { get; set; }
        public string BlDopUslojnenia { get; set; }
        public string BlDopPOStatus { get; set; }
        public string BlDopPreporaki { get; set; }
        public string BlDopPreporakiOPL { get; set; }
        public string BlDopDokumenti { get; set; }
        public bool BLDopPMS17 { get; set; }
        public string blDopEpi7 { get; set; }
        public string blDopEpi15 { get; set; }
        public string blDopEpi18 { get; set; }
        public string blDopEpi6a { get; set; }
    
        public virtual BolnichnoLechenie BolnichnoLechenie { get; set; }
    }
}
