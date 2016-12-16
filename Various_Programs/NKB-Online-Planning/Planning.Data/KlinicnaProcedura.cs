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
    
    public partial class KlinicnaProcedura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KlinicnaProcedura()
        {
            this.KlinProceduraCena = new HashSet<KlinProceduraCena>();
        }
    
        public decimal KlinicnaProceduraID { get; set; }
        public decimal DogovorNzokID { get; set; }
        public string KlinProKod { get; set; }
        public string KlinProIme { get; set; }
        public decimal KlinProStoinost { get; set; }
        public Nullable<decimal> KlinProPerNekorRehosp { get; set; }
        public string KlinProIziskvania { get; set; }
        public Nullable<bool> KlinProIsLegloden { get; set; }
        public string KlinProMinPrestoi { get; set; }
        public bool KlinProIsAktivna { get; set; }
        public decimal KlinProImplantanti { get; set; }
        public Nullable<decimal> KlinProDPBroi { get; set; }
        public string KlinProDPZad { get; set; }
        public Nullable<decimal> KlinProOPBroi { get; set; }
        public string KlinProOPZad { get; set; }
        public Nullable<decimal> KlinProTPBroi { get; set; }
        public string KlinProTPZad { get; set; }
        public bool KlinProSpec { get; set; }
        public bool KlinProIsStacionarna { get; set; }
        public bool isKlinProcAPr { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KlinProceduraCena> KlinProceduraCena { get; set; }
    }
}
