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
    
    public partial class Zveno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zveno()
        {
            this.BolnichnoLechenie = new HashSet<BolnichnoLechenie>();
            this.BolnichnoLechenie1 = new HashSet<BolnichnoLechenie>();
            this.DietOrder = new HashSet<DietOrder>();
            this.DietWardPersistance = new HashSet<DietWardPersistance>();
            this.DoctorsSchedule = new HashSet<DoctorsSchedule>();
            this.IzsDI = new HashSet<IzsDI>();
            this.IzsDI1 = new HashSet<IzsDI>();
            this.IzsEFI = new HashSet<IzsEFI>();
            this.IzsEFI1 = new HashSet<IzsEFI>();
            this.IzsFNI = new HashSet<IzsFNI>();
            this.IzsFNI1 = new HashSet<IzsFNI>();
            this.IzsIP = new HashSet<IzsIP>();
            this.IzsIP1 = new HashSet<IzsIP>();
            this.IzsLAB = new HashSet<IzsLAB>();
            this.IzsLAB1 = new HashSet<IzsLAB>();
            this.IzsROD = new HashSet<IzsROD>();
            this.IzsROD1 = new HashSet<IzsROD>();
            this.IzsVSI = new HashSet<IzsVSI>();
            this.IzsVSI1 = new HashSet<IzsVSI>();
            this.Konsultacia = new HashSet<Konsultacia>();
            this.LeglovaBaza = new HashSet<LeglovaBaza>();
            this.Obsajdane = new HashSet<Obsajdane>();
            this.Operacia = new HashSet<Operacia>();
            this.Order = new HashSet<Order>();
            this.Order1 = new HashSet<Order>();
            this.PACSModality = new HashSet<PACSModality>();
            this.PantheonCodes = new HashSet<PantheonCodes>();
            this.Pauza = new HashSet<Pauza>();
            this.Personal = new HashSet<Personal>();
            this.PersonalZveno = new HashSet<PersonalZveno>();
            this.PlaniraneOper = new HashSet<PlaniraneOper>();
            this.PlaniranePregled = new HashSet<PlaniranePregled>();
            this.Pochinali = new HashSet<Pochinali>();
            this.Pregled = new HashSet<Pregled>();
            this.Prevejdane = new HashSet<Prevejdane>();
            this.Proceduri = new HashSet<Proceduri>();
            this.Proceduri1 = new HashSet<Proceduri>();
            this.SubZveno = new HashSet<SubZveno>();
            this.WeightedCalculationByEventAndUnit = new HashSet<WeightedCalculationByEventAndUnit>();
        }
    
        public decimal ZvenoID { get; set; }
        public string ZvenoKod { get; set; }
        public string ZvenoIme { get; set; }
        public decimal ZvenoVid { get; set; }
        public Nullable<decimal> ZvenoTip { get; set; }
        public Nullable<decimal> ZvenoNormPreglNaDen { get; set; }
        public Nullable<decimal> ZvenoNormProdPregled { get; set; }
        public string ZvenoNacCasPregled { get; set; }
        public bool ZvenoIsOperativno { get; set; }
        public Nullable<decimal> ZvenoMedNapravlenie { get; set; }
        public Nullable<decimal> ZvenoPomeshtenie { get; set; }
        public decimal ZvenoBroiNemPers { get; set; }
        public bool ZvenoIsPatoAnatom { get; set; }
        public Nullable<decimal> ZvenoSpecialnost { get; set; }
        public bool ZvenoIsInvisible { get; set; }
        public Nullable<System.DateTime> ZvenoDoData { get; set; }
        public Nullable<decimal> ZvenoLabVid { get; set; }
        public bool ZvenoIsIntenzivno { get; set; }
        public Nullable<decimal> ZvenoVidNZOK { get; set; }
        public string PantheonKod { get; set; }
        public string DietWardName { get; set; }
        public Nullable<int> DietWardGroup { get; set; }
        public Nullable<bool> IsChildrensWard { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BolnichnoLechenie> BolnichnoLechenie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BolnichnoLechenie> BolnichnoLechenie1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DietOrder> DietOrder { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DietWardPersistance> DietWardPersistance { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoctorsSchedule> DoctorsSchedule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsDI> IzsDI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsDI> IzsDI1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsEFI> IzsEFI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsEFI> IzsEFI1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsFNI> IzsFNI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsFNI> IzsFNI1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsIP> IzsIP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsIP> IzsIP1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsLAB> IzsLAB { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsLAB> IzsLAB1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsROD> IzsROD { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsROD> IzsROD1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsVSI> IzsVSI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsVSI> IzsVSI1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Konsultacia> Konsultacia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LeglovaBaza> LeglovaBaza { get; set; }
        public virtual Nomenklatura Nomenklatura { get; set; }
        public virtual Nomenklatura Nomenklatura1 { get; set; }
        public virtual Nomenklatura Nomenklatura2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Obsajdane> Obsajdane { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operacia> Operacia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PACSModality> PACSModality { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PantheonCodes> PantheonCodes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pauza> Pauza { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personal> Personal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonalZveno> PersonalZveno { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlaniraneOper> PlaniraneOper { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlaniranePregled> PlaniranePregled { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pochinali> Pochinali { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pregled> Pregled { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prevejdane> Prevejdane { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proceduri> Proceduri { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proceduri> Proceduri1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubZveno> SubZveno { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WeightedCalculationByEventAndUnit> WeightedCalculationByEventAndUnit { get; set; }
    }
}
