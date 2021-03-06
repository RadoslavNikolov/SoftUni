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
    
    public partial class MedCentar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MedCentar()
        {
            this.DogovorNZOK = new HashSet<DogovorNZOK>();
            this.LimitiNZOK = new HashSet<LimitiNZOK>();
        }
    
        public decimal MedCentarID { get; set; }
        public Nullable<decimal> MCRegNomer { get; set; }
        public string MCIme { get; set; }
        public Nullable<bool> MCIsInvisible { get; set; }
        public Nullable<System.DateTime> MCDoData { get; set; }
        public string MCOblast { get; set; }
        public string MCObshtina { get; set; }
        public string MCAdres { get; set; }
        public Nullable<decimal> MCRZOK { get; set; }
        public Nullable<decimal> MCZR { get; set; }
        public string MCDanNomer { get; set; }
        public string MCBulstat { get; set; }
        public string MCBankaIme { get; set; }
        public string MCBankaKod { get; set; }
        public string MCBankaSmetka { get; set; }
        public Nullable<decimal> MCVid { get; set; }
        public byte[] MCLogo { get; set; }
        public Nullable<decimal> MCFacKrNo { get; set; }
        public Nullable<decimal> MCFacNachNo { get; set; }
        public string MCMol { get; set; }
        public string MCMolEGN { get; set; }
        public string MCMolUIN { get; set; }
        public byte[] MCAntetka { get; set; }
        public Nullable<decimal> MCKontragentNo { get; set; }
        public Nullable<decimal> MCBlNachNo { get; set; }
        public Nullable<decimal> MCBlKrNo { get; set; }
        public string MCFarmMolUIN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DogovorNZOK> DogovorNZOK { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LimitiNZOK> LimitiNZOK { get; set; }
        public virtual Nomenklatura Nomenklatura { get; set; }
    }
}
