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
    
    public partial class Bolnica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bolnica()
        {
            this.LimitiNZOK = new HashSet<LimitiNZOK>();
        }
    
        public decimal BolnicaID { get; set; }
        public string BolRegNomer { get; set; }
        public string BolIme { get; set; }
        public string BolFullIme { get; set; }
        public Nullable<bool> BolIsDispanser { get; set; }
        public string BolOblast { get; set; }
        public string BolObshtina { get; set; }
        public string BolAdres { get; set; }
        public Nullable<decimal> BolRZOK { get; set; }
        public Nullable<decimal> BolZR { get; set; }
        public string BolDanNomer { get; set; }
        public string BolBulstat { get; set; }
        public string BolBankaIme { get; set; }
        public string BolBankaKod { get; set; }
        public string BolBankaSmetka { get; set; }
        public string BolProv1 { get; set; }
        public string BolProv2 { get; set; }
        public byte[] BolLogo { get; set; }
        public string BolKod { get; set; }
        public Nullable<decimal> BolFacKrNo { get; set; }
        public Nullable<decimal> BolFacNachNo { get; set; }
        public string BolMol { get; set; }
        public string BolMolEGN { get; set; }
        public string BolMolUIN { get; set; }
        public byte[] BolAntetka { get; set; }
        public string BolEngIme { get; set; }
        public Nullable<decimal> BolKontragentNo { get; set; }
        public Nullable<decimal> BolVid { get; set; }
        public Nullable<decimal> BolBlNachNo { get; set; }
        public Nullable<decimal> BolBlKrNo { get; set; }
        public string FarmMolUIN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LimitiNZOK> LimitiNZOK { get; set; }
    }
}
