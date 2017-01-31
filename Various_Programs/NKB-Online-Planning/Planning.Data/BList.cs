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
    
    public partial class BList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BList()
        {
            this.Trudozaguba = new HashSet<Trudozaguba>();
        }
    
        public decimal ID { get; set; }
        public Nullable<decimal> BLID { get; set; }
        public string LNO { get; set; }
        public Nullable<System.DateTime> LData { get; set; }
        public Nullable<decimal> LVidOtp { get; set; }
        public Nullable<System.DateTime> LOtpStart { get; set; }
        public decimal LBroiDni { get; set; }
        public Nullable<decimal> LPrichina { get; set; }
        public string LBelejki { get; set; }
        public string LAK { get; set; }
        public string Company { get; set; }
        public string Profession { get; set; }
        public string WorkPosition { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyStreet { get; set; }
        public string CompanyStreetNo { get; set; }
        public string CompanyNeighborhood { get; set; }
        public Nullable<decimal> IcdCode { get; set; }
        public Nullable<System.DateTime> ExpDateOfDelivery { get; set; }
        public Nullable<System.DateTime> DateOfDelivery { get; set; }
        public string FamilyRelationship { get; set; }
        public string CompanionName { get; set; }
        public string DaysText { get; set; }
        public string CompanionIdentifier { get; set; }
        public Nullable<bool> CompanionEgn { get; set; }
        public Nullable<int> LKKNo { get; set; }
        public Nullable<System.DateTime> LKKDate { get; set; }
        public string TelkNo { get; set; }
        public Nullable<System.DateTime> TelkDate { get; set; }
        public Nullable<bool> LKK { get; set; }
        public string LKKType { get; set; }
        public string Doctor1Name { get; set; }
        public string Doctor2Name { get; set; }
        public string Doctor3Name { get; set; }
        public string Doctor1Uin { get; set; }
        public string Doctor2Uin { get; set; }
        public string Doctor3Uin { get; set; }
        public string PatientName { get; set; }
        public string PatientCity { get; set; }
        public string PatientAddress { get; set; }
        public Nullable<bool> PatientIsFemale { get; set; }
        public Nullable<bool> PatientIsEnch { get; set; }
        public string PatientEgn { get; set; }
        public Nullable<decimal> PatientAge { get; set; }
        public Nullable<decimal> PregledId { get; set; }
        public string ward_doctor_llk { get; set; }
        public Nullable<decimal> AmbListId { get; set; }
        public Nullable<decimal> BlLZ { get; set; }
        public Nullable<bool> Anuliran { get; set; }
        public Nullable<decimal> BlBelejki { get; set; }
        public string AnuliranBlNo { get; set; }
        public Nullable<bool> BlSend { get; set; }
        public Nullable<decimal> PrAnulirane { get; set; }
        public Nullable<decimal> BlRelationShip { get; set; }
        public Nullable<bool> LKKTypeNew { get; set; }
        public Nullable<System.DateTime> noiDate { get; set; }
        public string noiRef { get; set; }
        public string noiResponse { get; set; }
        public Nullable<decimal> KpLechenieID { get; set; }
        public Nullable<decimal> lkkId { get; set; }
        public string Belejki { get; set; }
    
        public virtual AmbList2005 AmbList2005 { get; set; }
        public virtual DoctorCommission DoctorCommission { get; set; }
        public virtual DoctorCommission DoctorCommission1 { get; set; }
        public virtual blXmlSent blXmlSent { get; set; }
        public virtual BolnichnoLechenie BolnichnoLechenie { get; set; }
        public virtual Nomenklatura Nomenklatura { get; set; }
        public virtual Nomenklatura Nomenklatura1 { get; set; }
        public virtual Diagnoza Diagnoza { get; set; }
        public virtual Pregled Pregled { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trudozaguba> Trudozaguba { get; set; }
    }
}