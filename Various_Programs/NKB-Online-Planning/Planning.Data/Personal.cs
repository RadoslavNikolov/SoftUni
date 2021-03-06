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
    
    public partial class Personal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personal()
        {
            this.Anestezia = new HashSet<Anestezia>();
            this.Anestezia1 = new HashSet<Anestezia>();
            this.BolnichnoLechenie = new HashSet<BolnichnoLechenie>();
            this.BolnichnoLechenie1 = new HashSet<BolnichnoLechenie>();
            this.BolnichnoLechenie2 = new HashSet<BolnichnoLechenie>();
            this.BolnichnoLechenie3 = new HashSet<BolnichnoLechenie>();
            this.DoctorCommission = new HashSet<DoctorCommission>();
            this.DoctorCommission1 = new HashSet<DoctorCommission>();
            this.DoctorCommission2 = new HashSet<DoctorCommission>();
            this.DoctorCommission3 = new HashSet<DoctorCommission>();
            this.DoctorCommission4 = new HashSet<DoctorCommission>();
            this.DoctorCommission5 = new HashSet<DoctorCommission>();
            this.DoctorCommission6 = new HashSet<DoctorCommission>();
            this.DoctorCommission7 = new HashSet<DoctorCommission>();
            this.DoctorCommission8 = new HashSet<DoctorCommission>();
            this.DoctorCommission9 = new HashSet<DoctorCommission>();
            this.DoctorCommission10 = new HashSet<DoctorCommission>();
            this.DoctorCommission11 = new HashSet<DoctorCommission>();
            this.DoctorHoliday = new HashSet<DoctorHoliday>();
            this.DoctorsSchedule = new HashSet<DoctorsSchedule>();
            this.IzsDI = new HashSet<IzsDI>();
            this.IzsEFI = new HashSet<IzsEFI>();
            this.IzsFNI = new HashSet<IzsFNI>();
            this.IzsIP = new HashSet<IzsIP>();
            this.IzsLAB = new HashSet<IzsLAB>();
            this.IzsROD = new HashSet<IzsROD>();
            this.IzsVSI = new HashSet<IzsVSI>();
            this.IzvunNKBKons = new HashSet<IzvunNKBKons>();
            this.Konsultacia = new HashSet<Konsultacia>();
            this.NZOKAmbGrafik = new HashSet<NZOKAmbGrafik>();
            this.Operacia = new HashSet<Operacia>();
            this.Operacia1 = new HashSet<Operacia>();
            this.Operacia2 = new HashSet<Operacia>();
            this.Operacia3 = new HashSet<Operacia>();
            this.Operacia4 = new HashSet<Operacia>();
            this.PersonalZveno = new HashSet<PersonalZveno>();
            this.PersonalRS1 = new HashSet<PersonalRS1>();
            this.Pochinali = new HashSet<Pochinali>();
            this.Pregled = new HashSet<Pregled>();
            this.Pregled1 = new HashSet<Pregled>();
            this.Proceduri = new HashSet<Proceduri>();
            this.PregnancyRegister = new HashSet<PregnancyRegister>();
        }
    
        public decimal PersonalID { get; set; }
        public decimal SpecialnostPersonalID { get; set; }
        public Nullable<decimal> ZvenoID { get; set; }
        public bool PersIsLekar { get; set; }
        public string PersEGN { get; set; }
        public string PersIme { get; set; }
        public string PersZvanie { get; set; }
        public bool PersIsInvisible { get; set; }
        public Nullable<System.DateTime> PersDoData { get; set; }
        public string PersUIN { get; set; }
        public Nullable<decimal> PersSimp { get; set; }
        public bool PersIsMC { get; set; }
        public bool PersIsENC { get; set; }
        public bool PersIsSpecializant { get; set; }
        public decimal PersNNAl { get; set; }
        public decimal PersNNDd { get; set; }
        public decimal PersNNN3 { get; set; }
        public decimal PersNNN3A { get; set; }
        public decimal PersNNN4 { get; set; }
        public decimal PersNNN6 { get; set; }
        public Nullable<decimal> PersNNRec { get; set; }
        public string PersTel { get; set; }
        public Nullable<bool> PersNachKlinika { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Anestezia> Anestezia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Anestezia> Anestezia1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BolnichnoLechenie> BolnichnoLechenie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BolnichnoLechenie> BolnichnoLechenie1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BolnichnoLechenie> BolnichnoLechenie2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BolnichnoLechenie> BolnichnoLechenie3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoctorCommission> DoctorCommission { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoctorCommission> DoctorCommission1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoctorCommission> DoctorCommission2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoctorCommission> DoctorCommission3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoctorCommission> DoctorCommission4 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoctorCommission> DoctorCommission5 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoctorCommission> DoctorCommission6 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoctorCommission> DoctorCommission7 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoctorCommission> DoctorCommission8 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoctorCommission> DoctorCommission9 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoctorCommission> DoctorCommission10 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoctorCommission> DoctorCommission11 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoctorHoliday> DoctorHoliday { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoctorsSchedule> DoctorsSchedule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsDI> IzsDI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsEFI> IzsEFI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsFNI> IzsFNI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsIP> IzsIP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsLAB> IzsLAB { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsROD> IzsROD { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzsVSI> IzsVSI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IzvunNKBKons> IzvunNKBKons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Konsultacia> Konsultacia { get; set; }
        public virtual Nomenklatura Nomenklatura { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NZOKAmbGrafik> NZOKAmbGrafik { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operacia> Operacia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operacia> Operacia1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operacia> Operacia2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operacia> Operacia3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operacia> Operacia4 { get; set; }
        public virtual SpecialnostPersonal SpecialnostPersonal { get; set; }
        public virtual Zveno Zveno { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonalZveno> PersonalZveno { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonalRS1> PersonalRS1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pochinali> Pochinali { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pregled> Pregled { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pregled> Pregled1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proceduri> Proceduri { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PregnancyRegister> PregnancyRegister { get; set; }
    }
}
