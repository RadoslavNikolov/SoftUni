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
    
    public partial class SpeshenList
    {
        public decimal SpListID { get; set; }
        public decimal PacientID { get; set; }
        public decimal LekarID { get; set; }
        public decimal LZID { get; set; }
        public decimal PregledID { get; set; }
        public int PacZO { get; set; }
        public decimal SpListNo { get; set; }
        public Nullable<decimal> NasOt { get; set; }
        public Nullable<decimal> NasKam { get; set; }
        public bool BList { get; set; }
        public string BListNo { get; set; }
        public bool Recepta { get; set; }
        public bool Izvestie { get; set; }
        public bool EtEpikriza { get; set; }
        public Nullable<decimal> MainDiag1 { get; set; }
        public Nullable<decimal> MainDiag2 { get; set; }
        public Nullable<decimal> DopDiag1 { get; set; }
        public Nullable<decimal> DopDiag2 { get; set; }
        public Nullable<decimal> DopDiag3 { get; set; }
        public Nullable<decimal> DopDiag4 { get; set; }
        public string Anamnesa { get; set; }
        public string HState { get; set; }
        public string Examine { get; set; }
        public string Therapy { get; set; }
        public Nullable<System.DateTime> K1Naz { get; set; }
        public string K1Txt { get; set; }
        public Nullable<System.DateTime> K2Naz { get; set; }
        public string K2Txt { get; set; }
        public Nullable<System.DateTime> K3Naz { get; set; }
        public string K3Txt { get; set; }
        public Nullable<System.DateTime> K4Naz { get; set; }
        public string K4Txt { get; set; }
        public string HospZvenoID { get; set; }
        public bool Zak1 { get; set; }
        public bool Zak2 { get; set; }
        public bool Zak3 { get; set; }
        public Nullable<bool> Zak11 { get; set; }
    
        public virtual Pregled Pregled { get; set; }
    }
}
