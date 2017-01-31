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
    
    public partial class NovoRodeni
    {
        public decimal ID { get; set; }
        public decimal BolID { get; set; }
        public decimal PacID { get; set; }
        public Nullable<System.DateTime> NovoTermin { get; set; }
        public Nullable<decimal> NovoMorfZr { get; set; }
        public Nullable<decimal> NovoTeglo { get; set; }
        public Nullable<decimal> NovoRst { get; set; }
        public Nullable<decimal> NovoGlava { get; set; }
        public Nullable<decimal> NovoGrdi { get; set; }
        public Nullable<System.DateTime> NovoBcjData { get; set; }
        public string NovoBcjNo { get; set; }
        public Nullable<System.DateTime> NovoHepData { get; set; }
        public string NovoHepNo { get; set; }
        public Nullable<System.DateTime> NovoPlmData { get; set; }
        public string NovoPlmNo { get; set; }
        public Nullable<System.DateTime> NovoFkuData { get; set; }
        public string MamIzNo { get; set; }
        public Nullable<decimal> NovoApgar1 { get; set; }
        public Nullable<decimal> NovoApgar5 { get; set; }
        public Nullable<decimal> NovoMorfZrDays { get; set; }
    
        public virtual BolnichnoLechenie BolnichnoLechenie { get; set; }
        public virtual Pacient Pacient { get; set; }
    }
}