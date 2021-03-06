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
    
    public partial class TabelaMedi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TabelaMedi()
        {
            this.TabelaMediIzp = new HashSet<TabelaMediIzp>();
        }
    
        public decimal TMId { get; set; }
        public decimal OrderID { get; set; }
        public decimal PacientID { get; set; }
        public Nullable<decimal> BolID { get; set; }
        public Nullable<decimal> PregledID { get; set; }
        public string TMTabelaNo { get; set; }
        public System.DateTime TMTabelaData { get; set; }
        public decimal TMTabelaVid { get; set; }
        public decimal TMTabelaZveno { get; set; }
        public System.DateTime TMIzpalnenie { get; set; }
        public Nullable<decimal> TMSklad { get; set; }
        public string PantheonId { get; set; }
        public string PantheonZveno { get; set; }
    
        public virtual BolnichnoLechenie BolnichnoLechenie { get; set; }
        public virtual Order Order { get; set; }
        public virtual Pacient Pacient { get; set; }
        public virtual Pregled Pregled { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TabelaMediIzp> TabelaMediIzp { get; set; }
    }
}
